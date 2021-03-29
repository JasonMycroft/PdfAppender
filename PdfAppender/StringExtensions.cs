using System;
using System.IO;

namespace PdfAppender
{
    public static class StringExtentions
    {
        /// <summary>
        /// Updates a filename such that it would be a valid new PDF filename.
        /// </summary>
        /// <param name="fullpath">The filename to update.</param>
        /// <returns>The path to a PDF file that does not exist.</returns>
        public static string UpdateOutputFilename(this string fullpath)
        {
            if (!fullpath.EndsWith(".pdf", StringComparison.InvariantCultureIgnoreCase))
            {
                fullpath += ".pdf";
            }

            if (File.Exists(fullpath))
            {
                int i = 1;
                string templatePath = fullpath.Insert(fullpath.LastIndexOf('.'), " ({0})");
                while (File.Exists(string.Format(templatePath, i)))
                {
                    i++;
                }

                fullpath = string.Format(templatePath, i);
            }

            return fullpath;
        }
    }
}
