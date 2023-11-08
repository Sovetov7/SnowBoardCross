using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.TourWeb
{
    public partial class TourWebFinals : Form
    {
        private int groups = DataBank.countGroup;
        static string[,] array;
        static string choice = DataBank.choice;
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
                    /*DataBank.countGroup = groups / 2;
                    TourWeb1_2 form = new TourWeb1_2();
                    form.Show();
                    Hide();*/
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
                case 3:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 4:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 5:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 6:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 7:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
                case 8:
                    result = CheckOrFill(gridRace, raceNumber, action);
                    break;
            }
            return result;
        }
        private string FillingDataGrid(DataGridView gridRace, int raceNumber)
        {
            int tourColumns = 4;
            int countParticipants = DataBank.countParticipantsInWeb;
            string[,] array = new string[countParticipants, tourColumns];
            for (int i = 0; i < countParticipants; i++)
            {
                array[i, 0] = DataBank.tourArray[i, 0];
                array[i, 1] = DataBank.tourArray[i, 1];
            }

            int partsInGroup = DataBank.countParticipantsInGroup;
            gridRace.RowCount = partsInGroup;
            gridRace.ColumnCount = tourColumns;
            gridRace.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            gridRace.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //gridRace.Columns[0].Width = 20;
            gridRace.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            int tourRows = (raceNumber - 1) * partsInGroup + partsInGroup;
            int k = 0;
            for (int i = (raceNumber - 1) * partsInGroup; i < tourRows; i++)
            {
                for (int j = 0; j < tourColumns; j++)
                {
                    if (k < partsInGroup)
                    {
                        gridRace.Rows[k].Cells[j].Value = array[i, j];
                        if (j == partsInGroup - 1 || j == partsInGroup - 2) gridRace.Rows[k].Cells[j].ReadOnly = false;
                        else gridRace.Rows[k].Cells[j].ReadOnly = true;
                    }
                }
                k++;
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
                if (cell == "Q" || cell == "q")
                    qualCount++;
            }
            if (place != tourRows)
            {
                MessageBox.Show("Места в заезде " + raceNumber + " не распределены или распределены не верно");
                return "error";
            }
            else if (qualCount != tourRows / 2)
            {
                MessageBox.Show("Количество победителей в заезде " + raceNumber + " не верно");
                return "error";
            }
            else
            {
                int tourArrRows;
                tourArrRows = (raceNumber - 1) * (tourRows / 2) + tourRows / 2;

                int k = (raceNumber - 1) * (tourRows / 2);
                for (int i = 0; i < tourRows; i++)
                {
                    if (k < tourArrRows)
                    {
                        string cell = (string)gridRace.Rows[i].Cells[3].Value;
                        if (cell == "Q" || cell == "q")
                        {
                            for (int j = 0; j < tourColumns; j++)
                                array[k, j] = gridRace.Rows[i].Cells[j].Value.ToString();
                            k++;
                        }
                    }
                }
                if (raceNumber == countParticipants / 2)
                    DataBank.tourArray = array;

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
