using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReaderRaport.Models {
    public class Library {
        public string LibraryName { get; set; }
        public List<Book> BookList { get; set; }

        public Library(List<RawBook> RawList, string libraryName) {
            BookList = RawList.Select(x => new Book(x)).ToList();
            LibraryName = libraryName;
        }

    }
}