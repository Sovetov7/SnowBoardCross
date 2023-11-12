using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1.TourWeb
{
    public partial class TourWebFinals : Form
    {
        private int groups = DataBank.countGroup;
        static string[,] array;
        public TourWebFinals()
        {
            InitializeComponent();
            string result;
            DataGridView[] dataGridViews = new DataGridView[2] { GridRace1, GridRace2 };
            array = new string[DataBank.countParticipantsInWeb, 4];
            for (int i = 0; i < groups; i++)
            {
                result = SwitchDataGrid(dataGridViews[i], "fill");
                if (result == "error") break;
                else exportButton.Enabled = true;
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            



            string result;
            DataGridView[] dataGridViews = new DataGridView[2] { GridRace1, GridRace2 };
            for (int i = 0; i < groups; i++)
            {
                result = SwitchDataGrid(dataGridViews[i], "check");
                if (result == "error") break;
                else if (i == groups - 1)
                {
                    DataBank.ExportAllTables();
                }
            }
        }
        private string CheckOrFill(DataGridView gridRace, int raceNumber, string action)
        {
            string result = "";
            if (action == "fill") result = FillingDataGrid(gridRace, raceNumber);
            else if (action == "check") result = CheckDataGrid(gridRace, raceNumber);
            return result;
        }
        private string SwitchDataGrid(DataGridView gridRace, string action)
        {
            string result = "";
            string[] race = gridRace.Name.Split('e');
            int raceNumber = Convert.ToInt32(race[1]);
            switch (raceNumber)
            {
                case 1:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 2:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
            }
            return result;
        }
        private string FillingDataGrid(DataGridView gridRace, int raceNumber)
        {
            int tourColumns = 4;
            int countParticipants = DataBank.countParticipantsInWeb;
            
            array = new string[countParticipants, tourColumns];
            if(raceNumber == 1)
                for (int i = 0; i < countParticipants; i++)
                {
                    array[i, 0] = DataBank.tourArray[i, 0];
                    array[i, 1] = DataBank.tourArray[i, 1];
                }
            else
                for (int i = 0; i < countParticipants; i++)
                {
                    array[i, 0] = DataBank.finalMiniArray[i, 0];
                    array[i, 1] = DataBank.finalMiniArray[i, 1];
                }


            int partsInGroup = DataBank.countParticipantsInGroup;
            gridRace.RowCount = partsInGroup;
            gridRace.ColumnCount = tourColumns;

            gridRace.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRace.Columns[0].Width = 140;
            gridRace.Columns[1].Width = 60;
            gridRace.RowHeadersWidth = 80;
            gridRace.TopLeftHeaderCell.Value = "Участники";
            gridRace.Columns[0].HeaderText = "Фамилия Имя";
            gridRace.Columns[1].HeaderText = "Страна";
            gridRace.Columns[2].HeaderText = "Место";
            gridRace.Columns[3].HeaderText = "Примечания";
            gridRace.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridRace.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridRace.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridRace.Height = ((countParticipants*2) / groups) * 18 + 25;
            gridRace.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;

            for (int i = 0; i < partsInGroup; i++)
            {
                for (int j = 0; j < tourColumns; j++)
                {
                    gridRace.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
                    gridRace.Rows[i].Cells[j].Value = array[i, j];
                    gridRace.Rows[i].Cells[0].ReadOnly = true;
                    gridRace.Rows[i].Cells[1].ReadOnly = true;
                    gridRace.Rows[i].Cells[2].ReadOnly = false;
                    gridRace.Rows[i].Cells[3].ReadOnly = false;
                }
            }
            foreach (DataGridViewColumn column in gridRace.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            return "success";
        }
        private string CheckDataGrid(DataGridView gridRace, int raceNumber)
        {
            int countParticipants = DataBank.countParticipantsInWeb;
            int tourColumns = 4;
            int tourRows = gridRace.RowCount;
            int qualCount = 0;
            int place = tourRows;
            List<string> list = new List<string>();

            for (int i = 0; i < tourRows; i++)
                if (gridRace.Rows[i].Cells[2].Value != null)
                    list.Add(gridRace.Rows[i].Cells[2].Value.ToString());


            for (int i = 1; i <= list.Count(); i++)
                if (!list.Any(x => x == i.ToString()))
                {
                    place = -1;
                    break;
                }

            for (int i = 0; i < tourRows; i++) //строки
            {
                string cell = (string)gridRace.Rows[i].Cells[3].Value;
                if (raceNumber == 1 && (cell == "Gold" || cell == "gold" || cell == "g"))
                {
                    gridRace.Rows[i].Cells[3].Value = "Gold";
                    qualCount++;
                }
                else if (raceNumber == 1 && (cell == "Silver" || cell == "silver" || cell == "s"))
                {
                    gridRace.Rows[i].Cells[3].Value = "Silver";
                    qualCount++;
                }
                else if (raceNumber == 1 && (cell == "Bronze" || cell == "bronze" || cell == "b"))
                {
                    gridRace.Rows[i].Cells[3].Value = "Bronze";
                    qualCount++;
                }
                    
            }
            if (place != tourRows)
            {
                MessageBox.Show("Места в заезде " + raceNumber + " не распределены или распределены не верно");
                return "error";
            }
            else if (raceNumber == 1 && (qualCount != 3))
            {
                MessageBox.Show("Количество победителей в заезде " + raceNumber + " не верно");
                return "error";
            }
            else
            {
                DataBank.AllTables(gridRace, this.Text, raceNumber);

                return "success";
            }
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            DistrForm form = new DistrForm();
            form.Show();
            Hide();
        }

    }
}
