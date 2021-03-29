using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PdfAppender
{
    public class Appender
    {
        /// <summary>
        /// Combines several PDF files into a single PDF file. PDFs will be appended in lexicographical order.
        /// </summary>
        /// <param name="directory">The directory used to find files and creating output.</param>
        /// <param name="outputFile">The name of the output file.</param>
        public static void AppendPdfs(string directory, string outputFile)
        {
            var files = Directory.GetFiles(directory, "*.pdf");
            Array.Sort(files);

            using (var newDocument = new PdfDocument())
            {
                foreach(var file in files){
                    string fullpath = Path.Combine(directory, file);
                    using (var document = PdfReader.Open(fullpath, PdfDocumentOpenMode.Import))
                    {
                        for (int pageNumber = 0; pageNumber < document.PageCount; pageNumber++)
                        {
                            newDocument.AddPage(document.Pages[pageNumber]);
                        }
                    }
                }

                var outputPath = Path.Combine(directory, outputFile).UpdateOutputFilename();

                newDocument.Save(outputPath);
            }
        }

        /// <summary>
        /// Combines several image files into a single PDF file. Images will be appended in lexicographical order.
        /// </summary>
        /// <param name="directory">The directory used to find files and creating output.</param>
        /// <param name="outputFile">The name of the output file.</param>
        public static void AppendImages(string directory, string outputFile)
        {
            var files = Directory.GetFiles(directory).Where(filename => Regex.IsMatch(filename, @"\.(jpg|jpeg|png)$")).ToArray();
            Array.Sort(files);

            using (var document = new PdfDocument())
            {
                foreach (var file in files)
                {
                    var page = new PdfPage();
                    document.AddPage(page);
                    var graphics = XGraphics.FromPdfPage(page);

                    var image = XImage.FromFile(file);
                    graphics.DrawImage(image, 0, 0, page.Width, page.Height);
                }

                var outputPath = Path.Combine(directory, outputFile).UpdateOutputFilename();

                document.Save(outputPath);
            }
        }
    }
}
