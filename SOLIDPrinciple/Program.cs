using System;

namespace SOLIDPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new Report();
            report.Text = "Report text";
            report.Print(new ConsolePrinter());
            report.Print(new WordPrinter());
            report.Print(new PdfPrinter());
        }
    }

    interface IPrinter
    {
        void Print(string text);
    }

    interface IScaner
    {
        void Scan(byte[] photo);
    }

    class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать отчета через консоль");
            Console.WriteLine(text);
        }
    }

    class WordPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать отчета на ворд");
            Console.WriteLine(text);
        }
    }
    class PdfPrinter : IPrinter, IScaner
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать отчета на PDF");
            Console.WriteLine(text);
        }

        public void Scan(byte[] photo)
        {
            throw new NotImplementedException();
        }
    }

    class Report
    {
        public string Text { get; set; }

        public void GoToFirstPage()
        {
            Console.WriteLine("Переход к первой странице");
        }

        public void GoToLastPage()
        {
            Console.WriteLine("Переход к последней странице");
        }

        public void GoToPage(int pageNumber)
        {
            Console.WriteLine($"Переход к странице {pageNumber}");
        }

        public void Print(IPrinter printer)
        {
            printer.Print(Text);
        }
    }
}
