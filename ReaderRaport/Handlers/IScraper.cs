using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderRaport.Handlers {
    interface IScraper {

        /// <summary>Gets the cover url.</summary>
        /// <param name="bookName">Raw name of the book.</param>
        /// <param name="msg">Output message based on the process state.</param>
        /// <returns>Url of image.</returns>
        string GetCover(string bookName);

        /// <summary> Returns web service specific url on the base of book name. </summary>
        /// <param name = "bookName"> Raw name of the book. </param>
        string BookNamePrepareUrl(string bookName);

    }
}
