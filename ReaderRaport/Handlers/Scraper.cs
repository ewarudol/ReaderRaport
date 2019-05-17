using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ReaderRaport.Handlers {

    /// <summary> Specfic web servise scraper 
    /// </summary>
    public class LubimyCzytacScraper : IScraper {

        /// <summary>Gets the cover url.</summary>
        /// <param name="bookName">Raw name of the book.</param>
        /// <param name="msg">Output message based on the process state.</param>
        /// <returns>Url of image.</returns>
        /// <exception cref="WebException">Cover server is not resonding for given url</exception>
        /// <exception cref="NullReferenceException">Book doesn't exist in web service</exception>
        public string GetCover(string bookName) {

            string url = BookNamePrepareUrl(bookName);
            string href = "";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);
            foreach(HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='book-cover-size-60x84 float-l']")) {
                foreach (HtmlNode subNode in node.SelectNodes("img")) {
                    HtmlAttribute hrefAttr = subNode.Attributes["src"];
                    href=hrefAttr.Value;
                    return href;
                }
            }
            return href;
        }

        /// <summary>Returns web service specific url on the base of book name.</summary>
        /// <param name="bookName">Raw name of the book.</param>
        /// <returns></returns>
        public string BookNamePrepareUrl(string bookName) {
            string url = "http://lubimyczytac.pl/szukaj/ksiazki?phrase=";
            return url + bookName.Replace(' ', '+');
        }

    }
}