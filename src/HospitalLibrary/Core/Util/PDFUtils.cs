using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Util
{
    public class ParagraphInfo
    {
        public Section Section { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string BookmarkName { get; set; }
        public ParagraphAlignment? Allignment { get; set; }
        public string? Text { get; set; }

        public ParagraphInfo(Section section, string style, string bookmarkName, string name, 
            ParagraphAlignment? allignment = null, string? text = null)
        {
            Section = section;
            Name = name;
            Style = style;
            BookmarkName = bookmarkName;
            Allignment = allignment;
            Text = text;
        }
    }

    public class RowInfo
    {
        public string[] CellsText { get; set; }

        public RowInfo(string[] cellsText)
        {
            CellsText = cellsText;
        }
    }

    public class PDFUtils
    {
        public static Document CreateDocumentWithSection(string title, string subject, string author)
        {
            Document document = new Document();
            document.Info.Title = title;
            document.Info.Subject = subject;
            document.Info.Author = author;

            DefineStyles(document);

            Section section = document.AddSection();

            return document;
        }

        public static void RenderAndSaveDocument(Document document, string filename)
        {
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;

            renderer.RenderDocument();

            renderer.PdfDocument.Save(filename);

            Process.Start(filename);
        }

        /// <summary>
        /// Defines the styles used in the document.
        /// </summary>
        public static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        public static void DefineParagraph(ParagraphInfo paragraphInfo)
        {
            Paragraph paragraph = paragraphInfo.Section.AddParagraph(paragraphInfo.Name, paragraphInfo.Style);
            paragraph.AddBookmark(paragraphInfo.BookmarkName);
            if (paragraphInfo.Allignment.HasValue) paragraph.Format.Alignment = paragraphInfo.Allignment.Value;
            if (paragraphInfo.Text != null) paragraph.AddText(paragraphInfo.Text); 
        }

        public static void DefineTable(Document document, string[] columns, RowInfo[] rows)
        {
            if (rows.Length != 0 && (columns.Length != rows[0].CellsText.Length))
            {
                throw new Exception("Number of columns must be same as number of cells per row.");    
            }

            Table table = new Table();
            table.Borders.Width = 0.75;

            // row num coll
            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            foreach (string col in columns)
            {
                table.AddColumn(Unit.FromCentimeter(5));
            }

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;

            for (int i = 0; i < columns.Length; i++)
            {
                Cell cell = row.Cells[i];
                cell.AddParagraph(columns[i]);
            }

            for (int i = 0; i < rows.Length; i++)
            {
                row = table.AddRow();
                
                for (int j = 0; j < rows[i].CellsText.Length; j++)
                {
                    Cell cell = row.Cells[j];
                    cell.AddParagraph(rows[i].CellsText[j]);
                }

            }

            table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);
        }
    }
}
