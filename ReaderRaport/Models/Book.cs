using ReaderRaport.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReaderRaport.Models {
    public class Book : RawBook {

        //metadata about book
        public string CoverURL { get; set; }

        public Book(RawBook raw) {
            BookName = raw.BookName;
            Series = raw.Series;
            AuthorSurname = raw.AuthorName;
            AuthorName = raw.AuthorSurname;
            Genre = raw.Genre;
            ReadDate = raw.ReadDate;

            LubimyCzytacScraper scraper = new LubimyCzytacScraper();
            try {
                CoverURL = scraper.GetCover(BookName);
            } catch {
                CoverURL = "http://lgimages.s3.amazonaws.com/gc-md.gif";
            }
        }
    }
}