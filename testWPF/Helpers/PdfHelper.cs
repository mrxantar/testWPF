using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace testWPF.Helpers
{
    public static class PdfHelper
    {
        public static void IWTOpenPdf()
        {
            string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", "IWT 07.10.22.pdf");

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("PDF-файл не найден:\n" + pdfPath, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void REDOpenPdf()
        {
            string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", "RED 07.10.22.pdf");

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("PDF-файл не найден:\n" + pdfPath, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
