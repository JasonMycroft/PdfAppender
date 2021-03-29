using System;
using System.Text;

namespace PdfAppender
{
    public class Program
    {
        /// <summary>
        /// Combines several files into a single PDF.
        /// </summary>
        /// <param name="args">The command line arguments. 3 expected: mode directory outputFilename</param>
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (args.Length < 2)
            {
                throw new Exception("Expected parameters: mode, directory, outputFilename.");
            }

            var directory = args[1];
            var outFile = args[2];
            switch (args[0].ToLowerInvariant())
            {
                case "image":
                case "images":
                case "png":
                case "jpg":
                case "jpeg":
                    Appender.AppendImages(directory, outFile);
                    break;
                case "pdf":
                default:
                    Appender.AppendPdfs(directory, outFile);
                    break;
            }
        }
    }
}
