using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] compressedData;
            using (var memStream = new MemoryStream())
            {
                var reader = new PdfReader(File.ReadAllBytes(@"C:\origem.pdf"));
                var stamper = new PdfStamper(reader, memStream, PdfWriter.VERSION_1_4);
                var pageNum = reader.NumberOfPages;

                for (var i = 1; i <= pageNum; i++)
                    reader.SetPageContent(i, reader.GetPageContent(i));

                stamper.SetFullCompression();
                stamper.Close();
                reader.Close();

                compressedData = memStream.ToArray();
            }

            File.WriteAllBytes(@"C:\inetpub\wwwroot\github\PDFCompress\src\Temp\Arquivo.pdf", compressedData);
        }
    }
}
