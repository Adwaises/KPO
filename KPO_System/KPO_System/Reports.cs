using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using System.Data;

namespace KPO_System
{
    class Reports
    {

        // успеваемость
        public void createReportPupil(DataTable dt, string fio, DateTime dateBy, DateTime dateTo)
        {
            createJournal(dt, fio, dateBy, dateTo, "Ученик");
        }

        string md = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\";

        public void createReportClass(DataTable dt, string nClass, DateTime dateBy, DateTime dateTo)
        {
            var doc = new Document();
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            string nameFile = "Отчёт_об_успеваемости_" + nClass.ToString() + "_с_" + dateBy.ToString("dd.MM.yyy") + "_по_" + dateTo.ToString("dd.MM.yyy") + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(md + @nameFile, FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


            Phrase p = new Phrase("Отчёт об успеваемости",
            new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a = new Paragraph(p);
            a.Alignment = Element.ALIGN_CENTER;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            p = new Phrase("Класс: " + nClass,
            new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            doc.Add(a);

            p = new Phrase("Дата: с " + dateBy.ToString("dd.MM.yyyy") + " по " + dateTo.ToString("dd.MM.yyyy"),
            new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);


            if (dt.Columns.Count < 15)
            {
                doc.Add(createTableRepClassMany(dt, baseFont, 0, dt.Columns.Count));
            }
            else
            {
                int index = 3;
                int index2 = dt.Columns.Count;

                while ((index2 - index) >= 15)
                {
                    doc.Add(createTableRepClassMany(dt, baseFont, index, index + 15));
                    index += 15;
                }

                doc.Add(createTableRepClassMany(dt, baseFont, index, index + (index2 - index)));
            }




            doc.Close();
        }

        PdfPTable createTableRepClassMany(DataTable dt, BaseFont baseFont, int index1, int index2)
        {
            PdfPTable table = new PdfPTable((index2 - index1) + 3);
            table.SpacingBefore = 10;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            //table.WidthPercentage = 100;
            float[] colWidth = new float[(index2 - index1) + 3];

            PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[0].ToString(), new iTextSharp.text.Font(baseFont,
12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.Colspan = 1;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dt.Columns[1].ToString(), new iTextSharp.text.Font(baseFont,
12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.Colspan = 1;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dt.Columns[2].ToString(), new iTextSharp.text.Font(baseFont,
12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.Colspan = 1;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);

            colWidth[0] = 5f;
            colWidth[1] = 5f;
            colWidth[2] = 5f;

            //заголовки и ширина
            for (int i = index1; i < index2; i++)
            {

                cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                cell.MinimumHeight = 20;
                if (i > 2)
                {

                    cell.Rotation = 90;
                    //cell.MinimumHeight = 100;
                    colWidth[i - index1 + 3] = 1.5f;
                }
                table.AddCell(cell);
            }

            table.TotalWidth = (float)(((index2 - index1) + 3) * 20) + 250;
            table.LockedWidth = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][0]), new iTextSharp.text.Font(baseFont, 12,
 iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.MinimumHeight = 20;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][1]), new iTextSharp.text.Font(baseFont, 12,
iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.MinimumHeight = 20;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][2]), new iTextSharp.text.Font(baseFont, 12,
iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.MinimumHeight = 20;
                table.AddCell(cell);

                for (int j = index1; j < index2; j++)
                {

                    cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                     iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    cell.MinimumHeight = 20;

                    table.AddCell(cell);
                }
            }

            table.SetWidths(colWidth);
            return table;
        }

        public void createReportSchool(DataTable dt, DateTime dateBy, DateTime dateTo)
        {
            var doc = new Document();
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            string nameFile = "Отчёт_об_успеваемости_Школа_с_" + dateBy.ToString("dd.MM.yyy") + "_по_" + dateTo.ToString("dd.MM.yyy") + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(md + @nameFile, FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Phrase p = new Phrase("Отчёт об успеваемости",
           new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a = new Paragraph(p);
            a.Alignment = Element.ALIGN_CENTER;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            p = new Phrase("Школа",
            new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            doc.Add(a);

            p = new Phrase("Дата: с " + dateBy.ToString("dd.MM.yyyy") + " по " + dateTo.ToString("dd.MM.yyyy"),
            new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            if (dt.Columns.Count < 15)
            {
                doc.Add(createTableSchool(dt, baseFont));
            }
            else
            {
                int index = 1;
                int index2 = dt.Columns.Count;

                while ((index2 - index) >= 15)
                {
                    doc.Add(createTable(dt, baseFont, index, index + 15));
                    index += 15;
                }
                doc.Add(createTable(dt, baseFont, index, index + (index2 - index)));
            }

            doc.Close();
        }



        PdfPTable createTableSchool(DataTable dt, BaseFont baseFont)
        {
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            //table.WidthPercentage = 100;
            float[] colWidth = new float[dt.Columns.Count];


            //colWidth[0] = 5f;
            //colWidth[1] = 5f;
            //colWidth[2] = 5f;

            for (int i = 0; i < dt.Columns.Count; i++)
            {

                PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.MinimumHeight = 20;
                cell.Rotation = 90;
                colWidth[i] = 1f;
                table.AddCell(cell);
            }

            table.TotalWidth = (float)(dt.Columns.Count * 30);
            table.LockedWidth = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    PdfPCell cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                     iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    cell.MinimumHeight = 20;

                    table.AddCell(cell);
                }
            }

            colWidth[0] = 1.5f;
            table.SetWidths(colWidth);
            return table;
        }

        //посещаемость

        private PdfPTable createTable(DataTable dt, BaseFont baseFont, int index1, int index2)
        {
            PdfPTable table = new PdfPTable((index2 - index1) + 1);
            table.SpacingBefore = 10;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            //table.WidthPercentage = 100;
            float[] colWidth = new float[(index2 - index1) + 1];

            colWidth[0] = 5f;

            PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[0].ToString(), new iTextSharp.text.Font(baseFont,
12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            cell.Colspan = 1;

            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;


            //cell.MinimumHeight = 20;

            table.AddCell(cell);

            //заголовки и ширина
            for (int i = index1; i < index2; i++)
            {

                cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                if (i > 0)
                {
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_LEFT;
                }

                cell.MinimumHeight = 20;
                if (i > 0)
                {
                    cell.Rotation = 90;
                    colWidth[i - index1 + 1] = 1f;
                }
                table.AddCell(cell);
            }

            table.TotalWidth = (float)(((index2 - index1) + 1) * 20) + 100;
            table.LockedWidth = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][0]), new iTextSharp.text.Font(baseFont, 12,
 iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.MinimumHeight = 20;
                table.AddCell(cell);

                for (int j = index1; j < index2; j++)
                {

                    cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
                     iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    cell.Colspan = 1;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_CENTER;
                    cell.MinimumHeight = 20;

                    table.AddCell(cell);
                }
            }

            table.SetWidths(colWidth);
            return table;
        }


        public void createJournal(DataTable dt, string cl, DateTime dateBy, DateTime dateTo, string flag)
        {
            var doc = new Document();
            string nameFile;
            if (flag == "Ученик")
            {
                nameFile = "Отчёт_об_успеваемости_" + flag + "_" + cl + "_с_" + dateBy.ToString("dd.MM.yyy") + "_по_" + dateTo.ToString("dd.MM.yyy") + ".pdf";
            }
            else
            {
                nameFile = "Отчёт_о_посещаемости_" + flag + "_" + cl + "_с_" + dateBy.ToString("dd.MM.yyy") + "_по_" + dateTo.ToString("dd.MM.yyy") + ".pdf";
            }


            PdfWriter.GetInstance(doc, new FileStream(md + @nameFile, FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Phrase p;
            if (flag == "Ученик")
            {
                p = new Phrase("Отчёт об успеваемости",
                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            }
            else
            {
                p = new Phrase("Отчёт о посещаемости",
                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            }


            Paragraph a = new Paragraph(p);
            a.Alignment = Element.ALIGN_CENTER;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            p = new Phrase(flag + ": " + cl,
                new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));

            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            doc.Add(a);

            p = new Phrase("Дата: с " + dateBy.ToString("dd.MM.yyyy") + " по " + dateTo.ToString("dd.MM.yyyy"),
            new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            if ((dateTo - dateBy).Days <= 20)
            {
                doc.Add(createTable(dt, baseFont, 0, dt.Columns.Count));
            }
            else
            {
                int index = 1;
                while ((dateTo - dateBy).Days > 20)
                {
                    doc.Add(createTable(dt, baseFont, index, index + 20));
                    index += 20;
                    dateBy = dateBy.AddDays(20);
                }
                //конец
                doc.Add(createTable(dt, baseFont, index, index + 1 + (dateTo - dateBy).Days));
            }
            doc.Close();
        }
    }
}
