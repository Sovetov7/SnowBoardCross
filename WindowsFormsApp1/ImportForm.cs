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
using Microsoft.Office.Interop.Excel;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class ImportForm : Form
    {
        //Делаем импорт из DLL
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, out int lpdwProcessId);


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
                int maleCount = CountGender("М");
                int femaleCount = CountGender("Ж");

                labelMale.Text = maleCount.ToString();
                labelFemale.Text = femaleCount.ToString();
                DevideArray(maleCount, allRows, "М", allArray, QualGridMale, nextButtonMale);
                DevideArray(femaleCount, allRows, "Ж", allArray, QualGridFemale, nextButtonFemale);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл не выбран: " + ex.Message);
            }
        }
        private int CountGender(string gender)
        {
            return allArray.Cast<string>().Count(cell => cell == gender);
        }
        static void DevideArray(int count, int allRows, string gender, string[,] allArray, DataGridView qualGrid, System.Windows.Forms.Button button)
        {// разделение массива на м или ж
            int l = 0;
            DataBank.qualArrayColumns = allArray.GetLength(1);
            int columns = DataBank.qualArrayColumns;
            string[,] partArray = new string[count, columns];
            for (int i = 0; i < allRows; i++)
            {
                if (allArray[i, 3] == gender)//если в строке есьт
                {
                    for (int j = 0; j < columns - 1; j++)
                    {
                        if (j == 1)
                        {
                            Country[] countries = ISO3166.Country.List;
                            foreach (var country in countries)
                            {
                                if (country.Name == allArray[i, j])
                                {
                                    partArray[l, j + 1] = country.ThreeLetterCode;
                                }
                            }
                        }
                        else partArray[l, j + 1] = allArray[i, j];
                    }
                    l++;
                }
            }

            // сортировка массивов


            string[] partArrayData = new string[count];

            for (int i = 0; i < count; i++)
                for (int j = 1; j < columns; j++)
                    if (j == 3)
                        partArrayData[i] = partArray[i, j];

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
            for (int i = 1; i < count; i++)
            {
                if (Convert.ToInt32(partArray[i, 0]) != Convert.ToInt32(partArray[i - 1, 0]) - 1)
                    partArray[i, 0] = (Convert.ToInt32(partArray[i - 1, 0]) + 1).ToString();
            }
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

            qualGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            qualGrid.Columns[0].Width = 20;
            qualGrid.Columns[1].Width = 140;
            qualGrid.Columns[2].Width = 60;
            qualGrid.Columns[0].HeaderText = "№";
            qualGrid.Columns[1].HeaderText = "Фамилия Имя";
            qualGrid.Columns[2].HeaderText = "Страна";
            qualGrid.Columns[3].HeaderText = "Кв.Время";
            qualGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            qualGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            qualGrid.RowHeadersVisible = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    qualGrid.Rows[i].Cells[j].Value = partArray[i, j];
                    qualGrid.Rows[i].Cells[j].ReadOnly = true;
                }
            }
            foreach (DataGridViewColumn column in qualGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

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
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(ofd.FileName);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[1]; //получить 1-й лист
            var lastCell = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);//последнюю ячейку
            int lastColumn = (int)lastCell.Column;
            
            int lastRow = (int)lastCell.Row;
            allArray = new string[lastRow, lastColumn];
            for (int j = 0; j < lastColumn; j++) //по всем колонкам
                for (int i = 0; i < lastRow; i++) // по всем строкам
                    allArray[i, j] = excelWorkSheet.Cells[i + 1, j + 1].Text.ToString(); //считываем данные

            //Закрываем Excel
            excelWorkbook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkSheet);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
            
            //Подготовка к убийству процесса Excel
            int ExcelPID = 0;
            int Hwnd = 0;
            Hwnd = excelApp.Hwnd;
            System.Diagnostics.Process ExcelProcess;
            GetWindowThreadProcessId((IntPtr)Hwnd, out ExcelPID);
            ExcelProcess = System.Diagnostics.Process.GetProcessById(ExcelPID);
            //Конец подготовки к убийству процесса Excel

            excelApp.Quit(); // выйти из Excel
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            // убираем за собой
            GC.Collect(); 
            GC.WaitForPendingFinalizers();
            // Убийство процесса Excel
            ExcelProcess.Kill();
            ExcelProcess = null;
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
