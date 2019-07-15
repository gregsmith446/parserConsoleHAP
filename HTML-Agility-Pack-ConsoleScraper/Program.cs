using System;
using HtmlAgilityPack;

namespace HTML_Agility_Pack_ConsoleScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string CNNurl = "https://money.cnn.com/data/hotstocks/index.html";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(CNNurl);

            // Table Class ---> wsod_dataTable wsod_dataTableBigAlt
            // Table X Path ---> //*[@id="wsod_hotStocks"]/table[1]

            HtmlNodeCollection rows = htmlDoc.DocumentNode.SelectNodes("//table[contains(@class, 'wsod_dataTable')]//tr");

            int stockId = 0;

            foreach (var row in rows)
            {
                stockId++;

                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count <= 10)
                {
                    var companyName = cells[0].InnerText;
                    var price = cells[1].InnerText;
                    var change = cells[2].InnerText;
                    var pChange = cells[3].InnerText;

                    Console.WriteLine("Stock: {0}", stockId);
                    Console.WriteLine(companyName);
                    Console.WriteLine(price);
                    Console.WriteLine(change);
                    Console.WriteLine(pChange);
                }
            }





        }
    }
}
