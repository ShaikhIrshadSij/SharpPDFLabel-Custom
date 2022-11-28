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
            var myImageAsAStream = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("E:\\0caf54ae-3e7d-4e5a-9656-85e75edddd26.png"));
            labelCreator.AddImage(myImageAsAStream);
            labelCreator.AddText("Stripe No. 8 - CO101310 COLOR: Prussian Blue LOR: Prussian Blue", "Verdana", 7, embedFont: true);
            labelCreator.AddText("Philomela Philomela Philomela", "Verdana", 6, embedFont: true);
            labelCreator.AddText("Scan for product details and to quote, order or save.", "Verdana", 6, true, Enums.FontStyle.BOLD);
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
