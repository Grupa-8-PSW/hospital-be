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
        public string Name { get; set; }
        public string Style { get; set; }
        public string BookmarkName { get; set; }
        public ParagraphAlignment? Allignment { get; set; }
        public string? Text { get; set; }
        public Unit FontSize { get; set; } = 16;
        public Unit SpaceAfter { get; set; } = "0cm";
        public Unit SpaceBefore { get; set; } = "0cm";
        public Color FontColor { get; set; } = Color.Parse("#0BDA51");

        public ParagraphInfo(string style, string bookmarkName, string name,
            ParagraphAlignment? allignment = null, string? text = null)
        {
            Name = name;
            Style = style;
            BookmarkName = bookmarkName;
            Allignment = allignment;
            Text = text;
        }

        public ParagraphInfo()
        {

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

    public static class PDFUtils
    {
        public static Document CreateDocumentWithSection(string title)
        {
            Document document = new Document();
            document.Info.Title = title;
            document.DefaultPageSetup.PageFormat = PageFormat.A4;
            DefineStyles(document);

            Section section = document.AddSection();

            return document;
        }

        public static void RenderAndSaveDocument(Document document, string filename)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
            renderer.Document = document;

            renderer.RenderDocument();

            renderer.PdfDocument.Save(filename);

            // Process.Start(new ProcessStartInfo { FileName = filename, UseShellExecute = true });
        }

        /// <summary>
        /// Defines the styles used in the document.
        /// </summary>
        private static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Verdana";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.LimeGreen;
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

            style = document.Styles["Heading4"];
            style.Font.Size = 8;
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
            style.ParagraphFormat.Font.Color = Colors.LimeGreen;
        }

        public static Paragraph DefineParagraph(ParagraphInfo paragraphInfo, Section section)
        {
            Paragraph paragraph = section.AddParagraph(paragraphInfo.Name, paragraphInfo.Style);
            paragraph.AddBookmark(paragraphInfo.BookmarkName);
            if (paragraphInfo.Allignment.HasValue) paragraph.Format.Alignment = paragraphInfo.Allignment.Value;
            if (paragraphInfo.Text != null) paragraph.AddText(paragraphInfo.Text);

            return paragraph;
        }

        public static void DefineTable(Document document, string[] columns, List<RowInfo> rows)
        {
            if (rows.Count != 0 && (columns.Length != rows[0].CellsText.Length))
            {
                throw new Exception("Number of columns must be same as number of cells per row.");
            }

            Table table = new Table();
            table.Borders.Width = 0.75;

            // Calculating column width
            int sectionWidth = (int)document.DefaultPageSetup.PageWidth
                - (int)document.DefaultPageSetup.LeftMargin
                - (int)document.DefaultPageSetup.RightMargin;
            float columnWidth = sectionWidth / columns.Length;

            foreach (string _ in columns)
            {
                Column addedCol = table.AddColumn(Unit.FromCentimeter(5));
                addedCol.Width = columnWidth;
            }

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;

            for (int i = 0; i < columns.Length; i++)
            {
                Cell cell = row.Cells[i];
                cell.AddParagraph(columns[i]);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                row = table.AddRow();

                for (int j = 0; j < rows[i].CellsText.Length; j++)
                {
                    Cell cell = row.Cells[j];
                    cell.AddParagraph(rows[i].CellsText[j]);
                }

            }

            table.SetEdge(0, 0, columns.Length, rows.Count, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);
        }
    }
}
