using System;
using System.Drawing;
using System.IO;

namespace SharpPDFLabel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the required label
            var label = new SharpPDFLabel.Labels.A4Labels.Avery.L5160();
            label.LabelsPerRow = 3;
            label.LabelRowsPerPage = 10;
            // Create a LabelCreator, passing the required label
            var labelCreator = new SharpPDFLabel.LabelCreator(label);
            var myImageAsAStream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("C:\\Users\\Vision-039\\Pictures\\Screenpresso\\2022-10-17_11h51_16.png"));
            labelCreator.AddImage(myImageAsAStream);
            labelCreator.AddText("Some Text", "Verdana", 10, embedFont: true);
            labelCreator.AddText("Some more text with bold and underlined text", "Verdana", 10, true, SharpPDFLabel.Enums.FontStyle.BOLD, SharpPDFLabel.Enums.FontStyle.UNDERLINE);
            labelCreator.IncludeLabelBorders = true;

            //Create the PDF as a stream
            var pdfStream = labelCreator.CreatePDF();
            SaveFileStream("E:\\Demo\\Sample.pdf", pdfStream);
            Console.WriteLine("PDF Generated");
            Console.ReadKey();
            //Do something with it!
            //Response.AddHeader("Content-Disposition", "attachment; filename=sheet_of_labels.pdf");
            //return new FileStreamResult(pdfStream, "application/pdf");
        }

        private static void SaveFileStream(string path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }
    }
}
