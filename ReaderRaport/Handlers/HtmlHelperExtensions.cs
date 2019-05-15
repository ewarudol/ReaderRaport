using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReaderRaport.Handlers {

    /// <summary>Extentions fo HtmlHelper (don't forget about Handlers reference, and using above the view)
    /// </summary>
    public static class HtmlHelperExtensions {

        /// <summary>
        /// Returns currents name of the view.
        /// </summary>
        /// <param name="html">Raw name without extention.</param>
        /// <returns></returns>
        public static string CurrentViewName(this HtmlHelper html) {
            return System.IO.Path.GetFileNameWithoutExtension(
                ((RazorView)html.ViewContext.View).ViewPath
            );
        }
    }
}