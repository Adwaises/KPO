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
        public void createReportPupil(DataTable dt, string fio, DateTime dateBy, DateTime dateTo)
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
            
            p = new Phrase("Ученик: " + fio,
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
            for (int i=0; i< dt.Columns.Count; i++)
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
                if (i>0)
                {
                    cell.Rotation = 90;
                    colWidth[i] = 1f;
                }
                table.AddCell(cell);
            }

            table.TotalWidth = (float)(dt.Columns.Count * 20)+100;
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

    }
}
