using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Collections.ObjectModel;
using ISO3166;

namespace WindowsFormsApp1
{
    public partial class ImportForm : Form
    {
        private string[,] allArray;
        public ImportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int allRows = ExportExcel();
                DataBank.qualArrayColumns = allArray.GetLength(1);
                int maleCount = CountGender("М");
                int femaleCount = CountGender("Ж");

                labelMale.Text = maleCount.ToString();
                labelFemale.Text = femaleCount.ToString();
                DevideArray(maleCount, allRows, "М", allArray, QualGridMale, nextButtonMale);
                DevideArray(femaleCount, allRows, "Ж", allArray, QualGridFemale, nextButtonFemale);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private int CountGender(string gender)
        {
            return allArray.Cast<string>().Count(cell => cell == gender);
        }
        static void DevideArray(int count, int allRows, string gender, string[,] allArray, DataGridView qualGrid, Button button)
        {// разделение массива на м и ж
            int l = 0;
            int columns = DataBank.qualArrayColumns;
            string[,] partArray = new string[count, columns];
            for (int i = 0; i < allRows; i++)
            {
                if (allArray[i, 3] == gender)
                {
                    for (int j = 0; j < columns - 1; j++)
                    {
                        if (j == 1)
                        {
                            Country[] countries = ISO3166.Country.List;
                            foreach (var country in countries)
                            {
                                if (country.Name == allArray[i,j])
                                {
                                    partArray[l, j+1] = country.ThreeLetterCode;
                                }
                            }
                        }
                        else partArray[l, j+1] = allArray[i, j];
                    }
                    l++;
                }
            }

            // сортировка массивов
            

            string[] partArrayData = new string[count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (j == 3)
                    {
                        partArrayData[i] = partArray[i, j];
                    }
                }
            }

            var orderedNumbers = partArrayData.OrderBy(n => n);
            int t = 0;
            foreach (string i in orderedNumbers)
            {
                partArrayData[t] = i;
                t++;
            }

            for (int i = 0; i < count; i++) // обход массива partArrayData
            {
                for (int j = 0; j < count; j++) // обход строк массива partArray
                {
                    if (partArrayData[i] == partArray[j, 3])
                    {
                        partArray[j, 0] = (i + 1).ToString();
                        for (int k = 0; k < columns; k++) // обход столбцов массива partArray 
                        {
                            string data = partArray[i, k];
                            partArray[i, k] = partArray[j, k].ToString();
                            partArray[j, k] = data;
                        }
                    }

                }
            }
            MessageBox.Show(count.ToString());
            if (gender == "М") DataBank.qualArrayMale = partArray;
            else DataBank.qualArrayFemale = partArray;
            DataBank.countParticipantsInQual = count;

            button.Enabled = true;
            TableOutput(qualGrid, count, columns, partArray);
        }
        static void TableOutput(DataGridView qualGrid, int rows,int columns, string[,] partArray)
        {
            qualGrid.RowCount = rows;
            qualGrid.ColumnCount = columns;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    qualGrid.Rows[i].Cells[j].Value = partArray[i, j];
                    qualGrid.Rows[i].Cells[j].ReadOnly = true;
                }
            }
            qualGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            qualGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            qualGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
        }
        private int ExportExcel()
        {
            // Выбрать путь и имя файла в диалоговом окне
            OpenFileDialog ofd = new OpenFileDialog
            {
                DefaultExt = "*.xls;*.xlsx",// Задаем расширение имени файла по умолчанию (открывается папка с программой)
                Filter = "файл Excel (Spisok.xlsx)|*.xlsx",// Задаем строку фильтра имен файлов, которая определяет варианты
                Title = "Выберите файл c данными"// Задаем заголовок диалогового окна
            };
            
            if (!(ofd.ShowDialog() == DialogResult.OK)) // если файл не выбран -> Выход
                return 0;
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(ofd.FileName);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; //получить 1-й лист
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            int lastColumn = (int)lastCell.Column;
            
            int lastRow = (int)lastCell.Row;
            allArray = new string[lastRow, lastColumn];
            for (int j = 0; j < lastColumn; j++) //по всем колонкам
                for (int i = 0; i < lastRow; i++) // по всем строкам
                    allArray[i, j] = ObjWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные
            ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            ObjWorkExcel.Quit(); // выйти из Excel
            GC.Collect(); // убрать за собой
            return lastRow;
        }

        private void nextButtonMale_Click(object sender, EventArgs e)
        {
            DataBank.choice = "М";
            OpenDistrForm();
        }

        private void nextButtonFemale_Click(object sender, EventArgs e)
        {
            DataBank.choice = "Ж";
            OpenDistrForm();
        }

        private void OpenDistrForm()
        {
            DistrForm form = new DistrForm();
            form.Show();
            Hide();
        }

    }
}
