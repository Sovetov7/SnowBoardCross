﻿using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.TourWeb;

namespace WindowsFormsApp1
{
    public partial class TourWeb1_2 : Form
    {
        private int groups = DataBank.countGroup;
        static string[,] array;
        static string[,] finalMiniArray;
        private int nextButtonCount = 0;
        public TourWeb1_2()
        {
            InitializeComponent();
            string result;
            DataGridView[] dataGridViews = new DataGridView[2] { GridRace1, GridRace2};
            for (int i = 0; i < groups; i++)
            {
                result = SwitchDataGrid(dataGridViews[i], "fill");
                if (result == "error") break;
                else nextButton.Enabled = true;
            }
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            string result;
            DataGridView[] dataGridViews = new DataGridView[2] { GridRace1, GridRace2};
            if (nextButtonCount == 0)
            {
                DataBank.countParticipantsInWeb /= 2;
                nextButtonCount++;
            }
            for (int i = 0; i < groups; i++)
            {
                result = SwitchDataGrid(dataGridViews[i], "check");
                if (result == "error") break;
                else if (i == groups - 1)
                {
                    TourWebFinals form = new TourWebFinals();
                    form.Show();
                    Hide();
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
            finalMiniArray = new string[countParticipants, tourColumns];
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
            gridRace.Height = (countParticipants / groups) * 18 + 25;
            gridRace.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;

            int tourRows = (raceNumber - 1) * partsInGroup + partsInGroup;
            int k = 0;
            for (int i = (raceNumber - 1) * partsInGroup; i < tourRows; i++)
            {
                for (int j = 0; j < tourColumns; j++)
                {
                    if (k < partsInGroup)
                    {
                        gridRace.Rows[k].HeaderCell.Value = string.Format((k + 1).ToString(), "0");
                        gridRace.Rows[k].Cells[j].Value = array[i, j];

                        gridRace.Rows[k].Cells[0].ReadOnly = true;
                        gridRace.Rows[k].Cells[1].ReadOnly = true;
                        gridRace.Rows[k].Cells[2].ReadOnly = false;
                        gridRace.Rows[k].Cells[3].ReadOnly = false;
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
            //////MiniFinal
            //////
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
                int f = (raceNumber - 1) * (tourRows / 2);
                for (int i = 0; i < tourRows; i++)
                {
                    string cell = (string)gridRace.Rows[i].Cells[3].Value;
                    if (k < tourArrRows && (cell == "Q" || cell == "q"))
                    {
                        for (int j = 0; j < tourColumns; j++)
                            array[k, j] = gridRace.Rows[i].Cells[j].Value.ToString();
                        k++;
                    }
                    else if (f < tourArrRows)
                    {
                        for (int j = 0; j < tourColumns; j++)
                        {
                            if (cell == null && j == 3) finalMiniArray[f, 3] = "";
                            else finalMiniArray[f, j] = gridRace.Rows[i].Cells[j].Value.ToString();
                        }
                        f++;
                    }
                }

                if (raceNumber == groups)
                {
                    DataBank.tourArray = array;
                    DataBank.finalMiniArray = finalMiniArray;
                }
                DataBank.AllTables(gridRace, this.Text, raceNumber);
                return "success";
            }
        }
        private void backButton_Click_1(object sender, EventArgs e)
        {
            DistrForm form = new DistrForm();
            form.Show();
            Hide();
        }
    }
}
