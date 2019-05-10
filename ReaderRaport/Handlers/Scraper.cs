using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReaderRaport.Handlers {
    public static class Scraper {

        public static List<string> GetHrefs(string url) {
            List<string> hrefs = new List<string>();
            HtmlWeb web = new HtmlWeb();
           
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);

            foreach(HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='book-cover-size-60x84 float-l']")) {
                foreach (HtmlNode subNode in node.SelectNodes("img")) {
                    HtmlAttribute hrefAttr = subNode.Attributes["src"];
                    hrefs.Add(hrefAttr.Value);
                }
                
            }
            return hrefs;
        }

        public static string BookNameSearchUrl(string bookName) {
            string url = "http://lubimyczytac.pl/szukaj/ksiazki?phrase=";
            return url + bookName.Replace(' ', '+');
        }

    }
}