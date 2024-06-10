using System.Text;
using Xfinium.Pdf;
using Xfinium.Pdf.Annotations;
using Xfinium.Pdf.Graphics;
using Xfinium.Pdf.Graphics.Text;

namespace TestingConsoleApp
{
  public class ReadAndFillPdf
  {
    public ReadAndFillPdf(string src, string dest)
    {
      Src = src;
      Dest = dest;
    }

    public string Src { get; }
    public string Dest { get; }

    public void Run()
    {
      PdfStandardFont helveticaBold6 = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 6);
      PdfStandardFont helveticaBold7 = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 7);
      PdfStandardFont helveticaBold8 = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 8);
      PdfStandardFont helveticaBold10 = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 10);

      PdfStandardFont helvetica = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 7);



      PdfStandardFont warningText = new PdfStandardFont(PdfStandardFontFace.HelveticaBold, 20);

      PdfBrush synapseOrangeBrush = new PdfBrush(new PdfRgbColor(228, 88, 27));
      PdfBrush blackBrush = new PdfBrush(PdfRgbColor.Black);
      PdfBrush redBrush = new PdfBrush(PdfRgbColor.Red);
      PdfBrush whiteBrush = new PdfBrush(PdfRgbColor.White);

      // PdfStringAppearanceOptions sao = new PdfStringAppearanceOptions();
      // sao.Brush = textBrush;
      // sao.Font = helvetica;

      FileStream srcFile = File.Open(Src, FileMode.Open, FileAccess.ReadWrite);

      var saveFile = File.Open(Dest, FileMode.Create);
      PdfFixedDocument document = new PdfFixedDocument(srcFile);



      // With fillable Forms
      // (document.Form.Fields["PatientName"] as PdfTextBoxField).Text = "John";
      // (document.Form.Fields["PatientDateOfBirth"] as PdfTextBoxField).Text = "07/07/1977";

      var page = document.Pages[0];

      // text-wrap
      // PdfStringLayoutOptions slo = new PdfStringLayoutOptions();
      // slo.HorizontalAlign = PdfStringHorizontalAlign.Left;
      // slo.VerticalAlign = PdfStringVerticalAlign.Top;
      // slo.X = 56;
      // slo.Y = 383;
      // slo.Width = 150;

      string text = "OXYCODONE-ACETAMINOPHEN TABS 10-325 MG";
      var value = text.Length > 25 ? text.Substring(0, 25) + "..." : text;
      // page.Graphics.DrawString(text, sao, slo);

      // get string that fits in box 
      // var value = PdfTextEngine.GetStringInBox(text, helvetica, 150, 10);

      var code = "SNO76";
      var rxBin = "999999";
      var groupNumber = "RTL88";
      var employer = "Test Employer";


      // page.Graphics.DrawString(code, helvetica, textBrush, 353, 207);

      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold7, 353, 206, 25);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold6, 408, 353, 22);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold8, 482, 489, 29);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold10, 125, 610, 35);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold7, 309, 667, 25);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold7, 527, 638, 25);
      // AddHighlightedText(page, code, synapseOrangeBrush, helveticaBold6, 547, 708, 22);

      page.Graphics.DrawString(code, helveticaBold7, synapseOrangeBrush, 353, 206);
      page.Graphics.DrawString(code, helveticaBold6, synapseOrangeBrush, 408, 353);
      page.Graphics.DrawString(code, helveticaBold8, synapseOrangeBrush, 482, 489);
      page.Graphics.DrawString(code, helveticaBold10, synapseOrangeBrush, 125, 610);
      page.Graphics.DrawString(code, helveticaBold7, synapseOrangeBrush, 309, 667);
      page.Graphics.DrawString(code, helveticaBold7, synapseOrangeBrush, 527, 638);
      page.Graphics.DrawString(code, helveticaBold6, synapseOrangeBrush, 547, 708);

      page.Graphics.DrawString(employer, helvetica, blackBrush, 125, 690);
      page.Graphics.DrawString(groupNumber, helvetica, blackBrush, 125, 710);
      page.Graphics.DrawString(rxBin, helvetica, blackBrush, 125, 729);



      byte[] buffer = Encoding.ASCII.GetBytes(document.ToString());
      saveFile.Write(buffer, 0, buffer.Length);
      document.Save(saveFile);
      saveFile.Flush();
      saveFile.Close();

    }



    protected static void AddHighlightedText(PdfPage page, string text, PdfBrush textBrush, PdfFont font, int x, int y, int width)
    {
      PdfStringAppearanceOptions sao = new PdfStringAppearanceOptions();
      sao.Brush = textBrush;
      sao.Font = font;
      // sao.Brush.Color = PdfRgbColor.Black;

      PdfStringLayoutOptions slo = new PdfStringLayoutOptions();
      slo.HorizontalAlign = PdfStringHorizontalAlign.Justified;
      slo.VerticalAlign = PdfStringVerticalAlign.Top;

      PdfTextMarkupAnnotation tma = new PdfTextMarkupAnnotation();
      page.Annotations.Add(tma);
      tma.VisualRectangle = new PdfVisualRectangle(x - 1, y - 2, width, font.Size + 2);
      tma.TextMarkupType = PdfTextMarkupAnnotationType.Highlight;
      tma.TextMarkupColor = PdfRgbColor.Yellow;
      // tma.Opacity = .2;

      slo.X = x;
      slo.Y = y;

      // page.Graphics.DrawString(code, helvetica, textBrush, 353, 207);
      page.Graphics.DrawString(text, sao, slo);
    }
  }

  // protected static Tuple<PdfStringLayoutOptions, PdfStringAppearanceOptions> getSloAndSao(PdfBrush textBrush, int x, int y, int width)
  // {
  //   var font = new PdfStandardFont(PdfStandardFontFace.Helvetica, 8);

  //   PdfStringAppearanceOptions sao = new PdfStringAppearanceOptions();
  //   sao.Brush = textBrush;
  //   sao.Font = font;

  //   PdfStringLayoutOptions slo = new PdfStringLayoutOptions();
  //   slo.HorizontalAlign = PdfStringHorizontalAlign.Justified;
  //   slo.VerticalAlign = PdfStringVerticalAlign.Top;
  //   slo.X = x;
  //   slo.Y = y;
  //   slo.Width = width;

  //   return Tuple.Create(slo, sao);
  // }
}