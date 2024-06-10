using System.Text;
using Xfinium.Pdf;
using Xfinium.Pdf.Annotations;
using Xfinium.Pdf.Graphics;
using Xfinium.Pdf.Graphics.Text;

namespace TestingConsoleApp
{
  public class AnnotatePdfCoordinates
  {
    public AnnotatePdfCoordinates(string src, string dest)
    {
      Src = src;
      Dest = dest;
    }

    public string Src { get; }
    public string Dest { get; }

    public void Run()
    {
      PdfStandardFont helvetica = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 7);
      PdfBrush redBrush = new PdfBrush(PdfRgbColor.Red);

      FileStream srcFile = File.Open(Src, FileMode.Open, FileAccess.ReadWrite);

      var saveFile = File.Open(Dest, FileMode.Create);
      PdfFixedDocument document = new PdfFixedDocument(srcFile);
      var page = document.Pages[0];

      for (var x = 40; x <= 600; x += 75)

      {

        for (var y = 25; y <= 800; y += 25)

        {

          page.Graphics.DrawString($"({x},{y})", helvetica, redBrush, x, y);

        }

      }

      byte[] buffer = Encoding.ASCII.GetBytes(document.ToString());
      saveFile.Write(buffer, 0, buffer.Length);
      document.Save(saveFile);
      saveFile.Flush();
      saveFile.Close();

    }

  }

}