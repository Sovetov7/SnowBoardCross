using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.TourWeb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace WindowsFormsApp1
{
    public partial class DistrForm : Form
    {
        public DistrForm()
        {
            InitializeComponent();
            if (DataBank.choice == "М") Text += ": Мужчины";
            else Text += ": Женщины";
            countCBQual.DropDownStyle = ComboBoxStyle.DropDownList;
            groupCBQual.DropDownStyle = ComboBoxStyle.DropDownList;
            groupCBQual.SelectedIndexChanged += groupCBQualMale_SelectedIndexChanged;
        }

        private void QualRaspr_Click(object sender, EventArgs e)
        {
            try
            {
                int partCount = Convert.ToInt32(countCBQual.Text);
                int groupCount = Convert.ToInt32(groupCBQual.Text);
                if (DataBank.countParticipantsInQual < partCount) MessageBox.Show("Выбранное количество участников превышает количество имеющихся");
                else
                {
                    DataBank.countParticipantsInWeb = partCount;
                    DataBank.countGroup = groupCount;
                    TableDistribution(partCount, groupCount, qualGrid);
                }
                TourWebButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Данные не введены");
            }
            
        }
        /*
        таблица расппределения для 32 человек по 8 групп, где в каждой по 4 участника, должна выглядеть так:
        1 16 17 32
        8 9  24 25
        5 12 21 28
        4 13 20 29
        3 14 19 30
        6 11 22 27
        7 10 23 26
        2 15 18 31
        Точного способа достичь таких последовательностей не найдено, поэтому принято было искать закономености:
        - каждый столбец состоит чисел, чередующихся: четный-нечетный-четный-нечетный
        - нечетные начинаются с наименьшего числа, а четные с наибольшего для этого столбца
        - суммы пар участников из каждых 2 групп идущих подряд равны какому-то одному числу (например для первого столбца 1+8 = 5+4 = 3+6 = 7+2 = 9) дальше суммы столбцов: 25, 41, 57
        такие суммы можно получить если сделать формулу: (наибольшее число столбца) + (наибольшее число предыддущего столбца. 0, если столбец первый) + 1
        - четные столбцы начинаются с чётного числа, нечетные с нечетного
        - в центре нечетных столбцов располагаются числа на 3 и на 2 больше наиМеньшего числа в столбце (например 4 и 3 для 1-го столбца, Наим = 1)
        - в центре четных столбцов располагаются числа на 3 и на 2 меньше наиБольшего числа в столбце (например 13 и 14 для 2-го столбца, Наиб = 16)

        Сначала нужно составить двумерный массив где с начала считаются и записываются в массив нечетные(1 3 5 7), а потом четные(8 6 4 2)и записываются чередуясь (1 8 3 6 5 4 7 2).
        Дальше, поскольку в центре нечетных столбцов должны располагаться числа на 2 и на 3 больше/меньше наименьшего/наибольшего соответственно, то эти числа меняются местами с теми числами, что находятся на этом месте в первом составленном массиве. (например для 1-го столбца число 3 меняется с 5, а 4 с 6)
        Такими перестановками составляется правильный массив. (1 8 5 4 3 6 7 2)

        */
        static void TableDistribution(int participantsCount, int groupCount, DataGridView QualGrid)
        {
            int peopleInGroupCount = participantsCount / groupCount;
            DataBank.countParticipantsInGroup = peopleInGroupCount;
            QualGrid.RowCount = groupCount;
            QualGrid.ColumnCount = peopleInGroupCount;
            int[,] prntsArr = new int[groupCount, peopleInGroupCount];
            int nechetNum = 1;
            int chetnNum = 2;
            int number = 0;
            if (groupCount > 8)
            {
                for (int i = 0; i < peopleInGroupCount; i++) //столбцы
                { // 1 8 3 6 5 4 7 2
                    for (int j = 0; j < groupCount; j++) // строки 
                    { //цикл строк для нечетных чисел, таких как 1 3 5 7
                        if (i % 2 == 0)
                        {//группы 1 и 3
                            if (j % 2 == 0)
                            {
                                prntsArr[j, i] = nechetNum; //подсчет нечетных чисел, начиная с верха столбца
                                nechetNum += 2;
                            }
                        }
                        else
                        {// группы 2 и 4
                            if (j % 2 != 0)
                            {
                                prntsArr[j, i] = nechetNum;
                                nechetNum += 2;
                            }
                        }
                    }
                    for (int j2 = groupCount - 1; j2 > -1; j2--) // строки 
                    { //цикл строк для четных чисел, таких как 8 4 3 2

                        if (i % 2 == 0)
                        {//группы 1 и 3
                            if (j2 % 2 != 0)
                            {
                                prntsArr[j2, i] = chetnNum; //подсчет четных чисел, начиная с низа столбца
                                chetnNum = chetnNum + 2;
                            }
                        }
                        else
                        {// группы 2 и 4
                            if (j2 % 2 == 0)
                            {
                                prntsArr[j2, i] = chetnNum;
                                chetnNum = chetnNum + 2;
                            }
                        }
                    } // выход 1 8 3 6 5 4 7 2
                }//выход 16 9 14 11 12 13 10 15
            }
            //перестановка

            int[,] finaleArr = new int[groupCount, peopleInGroupCount];
            
            int sum = 0;
            for (int i = 0; i < peopleInGroupCount; i++) //столбцы
            {
                if (i % 2 == 0)
                {
                    number++;
                    finaleArr[0, i] = number;
                    number++;
                    finaleArr[groupCount - 1, i] = number; 
                    number++;
                    finaleArr[groupCount / 2, i] = number;
                    number++;
                    finaleArr[(groupCount / 2) - 1, i] = number;

                    finaleArr[1, i] = groupCount * (i + 1);
                    sum = finaleArr[0, i] + finaleArr[1, i];
                    //MessageBox.Show(sum.ToString());
                    finaleArr[groupCount - 2, i] = sum - finaleArr[groupCount - 1, i];
                    if (groupCount >= 8)
                    {
                        finaleArr[(groupCount / 2) + 1, i] = sum - finaleArr[groupCount / 2, i];
                        finaleArr[(groupCount / 2) - 2, i] = sum - finaleArr[(groupCount / 2) - 1, i];
                        if (groupCount > 8)
                        {
                            for (int j = 0; j < groupCount; j++)
                            {// обходим столбец еще раз и меняем найденное число с тем, что в центре столбца
                                if (finaleArr[j, i] != prntsArr[j, i])
                                {
                                    for (int k = 0; k < groupCount; k++)
                                    {
                                        if (finaleArr[k, i] == prntsArr[j, i])
                                        {
                                            finaleArr[j, i] = prntsArr[k, i];
                                        }
                                    }
                                    if (finaleArr[j, i] == 0)
                                    {
                                        finaleArr[j, i] = prntsArr[j, i];
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    int numberReverse = groupCount*(i+1);
                    
                    finaleArr[0, i] = numberReverse;
                    numberReverse--;
                    finaleArr[groupCount-1, i] = numberReverse;
                    numberReverse--;
                    finaleArr[groupCount/2, i] = numberReverse;
                    numberReverse--;
                    finaleArr[(groupCount/2)-1, i] = numberReverse;
                    number = groupCount * (i + 1);
                    
                    finaleArr[1, i] = sum;
                    sum += groupCount * (i + 1);
                    finaleArr[groupCount - 2, i] = sum - finaleArr[groupCount - 1, i];
                    if (groupCount >= 8)
                    {
                        finaleArr[(groupCount / 2) + 1, i] = sum - finaleArr[groupCount / 2, i];
                        finaleArr[(groupCount / 2) - 2, i] = sum - finaleArr[(groupCount / 2) - 1, i];
                        if (groupCount > 8)
                        {
                            for (int j = 0; j < groupCount; j++)
                            {
                                if (finaleArr[j, i] != prntsArr[j, i])
                                {
                                    for (int k = 0; k < groupCount; k++)
                                    {
                                        if (finaleArr[k, i] == prntsArr[j, i])
                                        {
                                            finaleArr[j, i] = prntsArr[k, i];
                                        }
                                    }
                                    if (finaleArr[j, i] == 0)
                                    {
                                        finaleArr[j, i] = prntsArr[j, i];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            /*for (int i = 0; i < peopleInGroupCount; i++) //столбцы
            {
                for (int j = 0; j < groupCount; j++) //строки
                {
                    if (i % 2 == 0)
                    {//нечетные группы
                        if (prntsArr[j, i] == prntsArr[0, i] + 2)
                        { // находим число на 2 больше наименьшего в столбце
                            for (int l = 0; l < groupCount; l++)
                            {// обходим столбец еще раз и меняем найденное число с тем, что в центре столбца
                                if (l == groupCount / 2)
                                {
                                    int zamena = prntsArr[l, i];
                                    finaleArr[l, i] = prntsArr[j, i];
                                    finaleArr[j, i] = zamena;
                                }
                            }
                        }
                        else if (prntsArr[j, i] == prntsArr[0, i] + 3)
                        { // находим число на 3 больше наименьшего в столбце
                            for (int l = 0; l < groupCount; l++)
                            { // обходим столбец еще раз и меняем найденное число с тем, что в центре столбца
                                if (l == (groupCount / 2) - 1)
                                {
                                    int zamena = prntsArr[l, i];
                                    finaleArr[l, i] = prntsArr[j, i];
                                    finaleArr[j, i] = zamena;
                                }
                            }
                        }
                    }
                    else
                    { //четные группы
                        if (prntsArr[j, i] == prntsArr[0, i] - 2)
                        { // находим число на 2 меньше наибольшего в столбце
                            for (int l = 0; l < groupCount; l++)
                            { // обходим столбец еще раз и меняем найденное число с тем, что в центре столбца
                                if (l == groupCount / 2)
                                {
                                    int zamena = prntsArr[l, i];
                                    finaleArr[l, i] = prntsArr[j, i];
                                    finaleArr[j, i] = zamena;
                                }
                            }
                        }
                        else if (prntsArr[j, i] == prntsArr[0, i] - 3)
                        { // находим число на 3 меньше наибольшего в столбце
                            for (int l = 0; l < groupCount; l++)
                            { // обходим столбец еще раз и меняем найденное число с тем, что в центре столбца
                                if (l == (groupCount / 2) - 1)
                                {
                                    int zamena = prntsArr[l, i];
                                    finaleArr[l, i] = prntsArr[j, i];
                                    finaleArr[j, i] = zamena;
                                }
                            }
                        }
                    }
                }
            }*/
            //выход 1 8 5 4 3 6 7 2
            //выход 16 9 12 13 14 11 10 15
            TableOutput(QualGrid, groupCount, peopleInGroupCount, finaleArr);
            DataBank.groupsQualArrayParticipants = finaleArr;

        }
        static void TableOutput(DataGridView qualGrid, int groupCount, int peopleInGroupCount, int[,] finaleArr)
        {
            for (int i = 0; i < groupCount; i++)
            {
                for (int j = 0; j < peopleInGroupCount; j++)
                {
                    qualGrid.Rows[i].Cells[j].Value = finaleArr[i, j];
                    qualGrid.Columns[j].HeaderText = "Уч" + (j + 1).ToString();
                    qualGrid.TopLeftHeaderCell.Value = "Группы";
                    qualGrid.Rows[i].Cells[j].ReadOnly = true;
                }
                qualGrid.Rows[i].HeaderCell.Value = (i + 1) + "        ";
            }
            qualGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            qualGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            qualGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        /*void countCBQualMale_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupCBQualMale.Items.Clear();
            if (countCBQualMale.SelectedIndex <= 1) groupCBQualMale.Items.Add("4");
            else if (countCBQualMale.SelectedIndex == 2)
            {
                groupCBQualMale.Items.Add("4");
                groupCBQualMale.Items.Add("8");
            }
            else if (countCBQualMale.SelectedIndex == 3) groupCBQualMale.Items.Add("8");
            else if (countCBQualMale.SelectedIndex == 4)
            {
                groupCBQualMale.Items.Add("8");
                groupCBQualMale.Items.Add("16");
            }
        }
        void countCBQualFemale_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupCBQualFemale.Items.Clear();
            if (countCBQualFemale.SelectedIndex <= 1) groupCBQualFemale.Items.Add("4");
            else if (countCBQualFemale.SelectedIndex == 2)
            {
                groupCBQualFemale.Items.Add("4");
                groupCBQualFemale.Items.Add("8");
            }
            else if (countCBQualFemale.SelectedIndex == 3) groupCBQualFemale.Items.Add("8");
            else if (countCBQualFemale.SelectedIndex == 4)
            {
                groupCBQualFemale.Items.Add("8");
                groupCBQualFemale.Items.Add("16");
            }
        }*/
        void groupCBQualMale_SelectedIndexChanged(object sender, EventArgs e)
        {
            countCBQual.Items.Clear();
            if (groupCBQual.SelectedIndex == 0)
            {
                countCBQual.Items.Add("16");
                //countCBQual.Items.Add("24");
                //countCBQual.Items.Add("32");
            }
            else if (groupCBQual.SelectedIndex == 1)
            {
                countCBQual.Items.Add("32");
                //countCBQual.Items.Add("48");
                //countCBQual.Items.Add("64");
            }
            else
            {
                countCBQual.Items.Add("64");
            }
        }
        
        private void TourWebButtonMale_Click(object sender, EventArgs e)
        {
            if (DataBank.countGroup == 16)
            {
                TourWeb1_16 form = new TourWeb1_16();
                form.Show();
                Hide();
            }
            else if (DataBank.countGroup == 8)
            {
                TourWeb1_8 form = new TourWeb1_8("begin");
                form.Show();
                Hide();
            }
            else
            {
                TourWeb1_4 form = new TourWeb1_4("begin");
                form.Show();
                Hide();
            }

        }
    }
}
