// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using TestingConsoleApp;

Console.WriteLine("Hello, World!");
var src = "WriteInVoucher_Layout_20240514.pdf";
var dest = "Filled_WriteInVoucher_Layout_20240514.pdf";
// var newPdf = new ReadAndFillPdf(src, dest);
var newPdf = new AnnotatePdfCoordinates(src, dest);

newPdf.Run();

Console.WriteLine("Hello World!");

