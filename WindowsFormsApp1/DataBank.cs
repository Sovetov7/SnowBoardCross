using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DocumentInfo
    {
        public string partOfFinal { get; set; }
        public int raceNumber { get; set; }
        public PdfPTable pTable { get; set; }
    }
    internal static class DataBank
    {
        public static string choice; //ImportForm

        public static int countParticipantsInQual; //ImportForm

        public static string[,] qualArrayMale; //ImportForm
        public static string[,] qualArrayFemale; //ImportForm
        public static int qualArrayColumns;

        public static int countParticipantsInWeb; //DistrForm
        public static int countParticipantsInGroup; 
        public static int countGroup; 

        public static int[,] groupsQualArrayParticipants; //DistrForm

        public static string[,] tourArray; //tourWeb
        public static string[,] finalMiniArray; //tourWeb\

        public static List<DocumentInfo> list;

        private static BaseFont baseFont = BaseFont.CreateFont("c:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        private static Font font = new Font(baseFont);

        public static void ExportAllTables()
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF (*.pdf)|*.pdf";
            save.FileName = "Result.pdf";
            bool ErrorMessage = false;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    try
                    {
                        File.Delete(save.FileName);
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = true;
                        MessageBox.Show("Не удается записать данные на диск" + ex.Message);
                    }
                }
                if (!ErrorMessage)
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(document, fileStream);
                            document.Open();
                            for (int i = 0; i < list.Count(); i++)
                            {
                                int raceNum = list[i].raceNumber;
                                string finalName = list[i].partOfFinal;
                                PdfPTable raceTable = list[i].pTable;
                                if (finalName == "Большой и малый финалы" && raceNum == 1)
                                {
                                    document.Add(new Paragraph("\n"));
                                    document.Add(new Paragraph(new Phrase("Большой Финал", font)));
                                    document.Add(new Paragraph("\n"));
                                    document.Add(raceTable);
                                }
                                else if (finalName == "Большой и малый финалы" && raceNum == 2)
                                {
                                    document.Add(new Paragraph("\n"));
                                    document.Add(new Paragraph(new Phrase("Малый Финал", font)));
                                    document.Add(new Paragraph("\n"));
                                    document.Add(raceTable);
                                }
                                else if (raceNum == 1)
                                {
                                    document.Add(new Paragraph(new Phrase(finalName, font)));
                                    document.Add(new Paragraph(new Phrase("Заезд " + raceNum, font)));
                                    document.Add(new Paragraph("\n"));
                                    document.Add(raceTable);
                                }
                                else
                                {
                                    document.Add(new Paragraph("\n"));
                                    document.Add(new Paragraph(new Phrase("Заезд " + raceNum, font)));
                                    document.Add(new Paragraph("\n"));
                                    document.Add(raceTable);
                                }
                            }
                            document.Close();
                            fileStream.Close();
                        }
                        MessageBox.Show("Успешный экспорт данных", "info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while exporting Data" + ex.Message);
                    }
                    
                }
            }
            
        }

        public static void AllTables(DataGridView gridRace, string partOfFinal, int raceNumber)
        {
            /*DataGridView[] dataGridViews = new DataGridView[2] { GridRace1, GridRace2 };
            tablesArray = new string[gr];*/

            PdfPTable pTable = new PdfPTable(gridRace.Columns.Count);
            pTable.DefaultCell.Padding = 2;
            pTable.WidthPercentage = 100;
            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
            foreach (DataGridViewColumn col in gridRace.Columns)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, font));
                pTable.AddCell(pCell);
            }
            foreach (DataGridViewRow viewRow in gridRace.Rows)
            {
                foreach (DataGridViewCell dcell in viewRow.Cells)
                {
                    if (dcell.Value == null) pTable.AddCell(" ");
                    else pTable.AddCell(new Phrase(dcell.Value.ToString(), font));
                }
            }
            list.Add(new DocumentInfo { partOfFinal = partOfFinal, raceNumber = raceNumber, pTable = pTable });

        }
    }
}
