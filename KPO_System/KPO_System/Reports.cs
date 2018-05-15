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

            //var doc = new Document();
            //PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            //doc.Open();
            //BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //Phrase p = new Phrase("Отчёт об успеваемости",
            //new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            //Paragraph a = new Paragraph(p);
            //a.Alignment = Element.ALIGN_CENTER;
            //a.Add(Environment.NewLine);
            //a.SpacingAfter = 5;
            //doc.Add(a);

            //p = new Phrase("Ученик: " + fio,
            //new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            //a = new Paragraph(p);
            //a.Alignment = Element.ALIGN_LEFT;
            //a.Add(Environment.NewLine);
            //doc.Add(a);

            //p = new Phrase("Дата: с " + dateBy.ToString("dd.MM.yyyy") + " по " + dateTo.ToString("dd.MM.yyyy"),
            //new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            //a = new Paragraph(p);
            //a.Alignment = Element.ALIGN_LEFT;
            //a.Add(Environment.NewLine);
            //a.SpacingAfter = 5;
            //doc.Add(a);

            //if ((dateTo - dateBy).Days <= 20)
            //{
            //     PdfPTable table = new PdfPTable(dt.Columns.Count);
            //    table.HorizontalAlignment = Element.ALIGN_LEFT;
            //    //table.WidthPercentage = 100;
            //    float[] colWidth = new float[dt.Columns.Count];

            //    colWidth[0] = 5f;
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {

            //        PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
            //        12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            //        cell.Colspan = 1;
            //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //        cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            //        if (i > 0)
            //        {
            //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //            cell.VerticalAlignment = Element.ALIGN_LEFT;
            //        }

            //        cell.MinimumHeight = 20;
            //        if (i > 0)
            //        {
            //            cell.Rotation = 90;
            //            colWidth[i] = 1f;
            //        }
            //        table.AddCell(cell);
            //    }

            //    table.TotalWidth = (float)(dt.Columns.Count * 20) + 100;
            //    table.LockedWidth = true;

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {

            //            PdfPCell cell = new PdfPCell(new Phrase(Convert.ToString(dt.Rows[i][j]), new iTextSharp.text.Font(baseFont, 12,
            //             iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            //            cell.Colspan = 1;
            //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            //            cell.VerticalAlignment = Element.ALIGN_CENTER;
            //            cell.MinimumHeight = 20;

            //            table.AddCell(cell);
            //        }
            //    }

            //    table.SetWidths(colWidth);

            //    doc.Add(table);


            //} else
            //{
            //    int index = 1;
            //    while ((dateTo - dateBy).Days > 20)
            //    {
            //        doc.Add(createTable(dt, baseFont, index, index + 20));
            //        index += 20;
            //        dateBy = dateBy.AddDays(20);
            //    }
            //    //конец
            //    //dateBy = dateBy.AddDays(-20);
            //    doc.Add(createTable(dt, baseFont, index, index + 1 + (dateTo - dateBy).Days));
            //}
            //doc.Close();



        }

        public void createReportClass(DataTable dt, string nClass, DateTime dateBy, DateTime dateTo)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
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

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            //table.WidthPercentage = 100;
            float[] colWidth = new float[dt.Columns.Count];

            colWidth[0] = 5f;
            colWidth[1] = 5f;
            colWidth[2] = 5f;

            for (int i = 0; i < dt.Columns.Count; i++)
            {

                PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
                12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                cell.Colspan = 1;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;



                cell.MinimumHeight = 20;
                if (i > 2)
                {
                    cell.Rotation = 90;
                    colWidth[i] = 1f;
                }
                table.AddCell(cell);
            }

            table.TotalWidth = (float)(dt.Columns.Count * 20) + 300;
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

            table.SetWidths(colWidth);

            doc.Add(table);

            doc.Close();
        }

        public void createReportSchool(DataTable dt)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            doc.Open();


            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Phrase p = new Phrase("Ученик:",
            new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a = new Paragraph(p);
            a.Alignment = Element.ALIGN_LEFT;
            a.Add(Environment.NewLine);
            doc.Add(a);

            PdfPTable table = new PdfPTable(4);



            doc.Close();
        }

        //посещаемость



        private PdfPTable createTable(DataTable dt, BaseFont baseFont,int index1,int index2)
        {
                PdfPTable table = new PdfPTable((index2- index1)+1);
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
                        colWidth[i- index1+1] = 1f;
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
            PdfWriter.GetInstance(doc, new FileStream(@"Document.pdf", FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"ARIAL.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            Phrase p = new Phrase("Отчёт о посещаемости",
            new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            Paragraph a = new Paragraph(p);
            a.Alignment = Element.ALIGN_CENTER;
            a.Add(Environment.NewLine);
            a.SpacingAfter = 5;
            doc.Add(a);

            if (flag == "Класс")
            {
                p = new Phrase("Класс: " + cl,
new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            }
            else if(flag == "Дисциплина")
            {            
                p = new Phrase("Дисциплина: " + cl,
new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            }
            else if (flag == "Ученик")
            {
                p = new Phrase("Ученик: " + cl,
           new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black)));
            }



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
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                //table.WidthPercentage = 100;
                float[] colWidth = new float[dt.Columns.Count];

                colWidth[0] = 5f;
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    PdfPCell cell = new PdfPCell(new Phrase(dt.Columns[i].ToString(), new iTextSharp.text.Font(baseFont,
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
                        colWidth[i] = 1f;
                    }
                    table.AddCell(cell);
                }

                table.TotalWidth = (float)(dt.Columns.Count * 20) + 100;
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

                table.SetWidths(colWidth);
                doc.Add(table);
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
                //dateBy = dateBy.AddDays(-20);
                doc.Add(createTable(dt, baseFont, index, index + 1 + (dateTo - dateBy).Days));
            }




            doc.Close();
        }


    }
}
