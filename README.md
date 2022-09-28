# PdfAppender
.NET Core application for creating a PDF file from a combination of existing files in a directory.  
Files are appended in lexicographical order.

# Usage
Extract the zip file from the releases page and run using the command `dotnet PdfAppender\PdfAppender.dll {mode} {directory} {outputFilename}`.

# Command line arguments
{mode} {directory} {outputFilename}  
`mode`:  
&nbsp;&nbsp;image | images | png | jpg | jpeg: combine image(s) into a single PDF.  
&nbsp;&nbsp;pdf: combine multiple PDFs into a single PDF.  
`directory`:  
&nbsp;&nbsp;Files for combination will be retrieved from and output will be written to here.  
`outputFilename`:  
&nbsp;&nbsp;The name of the output file.
