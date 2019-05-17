using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReaderRaport.Models {

    public class RawBook {

        //csv specyfic data
        public string BookName { get; set; }
        public string Series { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public DateTime ReadDate { get; set; }

    }
}