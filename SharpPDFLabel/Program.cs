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
            label.LabelsPerRow = 2;
            label.LabelRowsPerPage = 5;
            // Create a LabelCreator, passing the required label
            var labelCreator = new SharpPDFLabel.LabelCreator(label);

            AddRow(ref labelCreator);
            AddRow(ref labelCreator);
            AddRow(ref labelCreator);
            AddRow(ref labelCreator);
            AddRow(ref labelCreator);
            AddRow(ref labelCreator);


            labelCreator.IncludeLabelBorders = true;

            //Create the PDF as a stream
            var pdfStream = labelCreator.CreatePDF();
            SaveFileStream("E:\\Demo\\Sample.pdf", pdfStream);
            Console.WriteLine("PDF Generated");
            //Console.ReadKey();
            //Do something with it!
            //Response.AddHeader("Content-Disposition", "attachment; filename=sheet_of_labels.pdf");
            //return new FileStreamResult(pdfStream, "application/pdf");
        }

        private static void AddRow(ref LabelCreator labelCreator)
        {
            labelCreator.AddImage(new System.IO.MemoryStream(System.IO.File.ReadAllBytes("D:\\Irshad\\SharpPDFLabel-Custom\\SharpPDFLabel\\Images\\IMG-20230722-WA0038.jpg")));
            labelCreator.AddText("Shaikh Irshad", "Verdana", 8, embedFont: true, Enums.FontStyle.BOLD);
            labelCreator.AddText("S/O: Jahangir", "Verdana", 7, embedFont: true);
            labelCreator.AddText("148-A-24, H-2, Near Amroli, Surat, Gujarat", "Verdana", 7, true);
            labelCreator.AddText("Mo: 98980-33490", "Verdana", 7, true);
            labelCreator.AddText("Aadhar: xxxx-xxxx-9901", "Verdana", 6, true);

            labelCreator.AddImage(new System.IO.MemoryStream(System.IO.File.ReadAllBytes("D:\\Irshad\\SharpPDFLabel-Custom\\SharpPDFLabel\\Images\\th.jpg")));
            labelCreator.AddText("Member Since: 2021", "Verdana", 7, embedFont: true);
            labelCreator.AddText("Work Type: NREGAWorker", "Verdana", 7, embedFont: true);
            labelCreator.AddText("Ration Card No: 34901939483", "Verdana", 7, true);
            labelCreator.AddText("Job Card No: 9012984911", "Verdana", 7, true);
            labelCreator.AddText("Printed: 2023-03-15, manmudra.org", "Verdana", 6, true);
        }

        private static void SaveFileStream(string path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }
    }
}
