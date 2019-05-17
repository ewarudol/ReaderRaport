using CsvHelper;
using ReaderRaport.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ReaderRaport.Handlers {

    /// <summary>Handler for processing HTTP file and mapping for specific Model</summary>
    /// <typeparam name="T">Model for CSV mapping</typeparam>
    /// <exception cref="HeaderValidationException">When header of CSV file isn't same as Model fields</exception>
    public class CSVHandler<T> {

        public List<T> SaveWebCSV(HttpPostedFileBase file) {
            TextReader reader = new StreamReader((file.InputStream));
            CsvReader csvReader = new CsvReader(reader);
            List<T> records = csvReader.GetRecords<T>().ToList();
            return records;
        }

        /// <summary>
        /// Gets the name of the file without extention.
        /// </summary>
        /// <param name="fileData">Raw http file</param>
        /// <returns></returns>
        public string GetFileName(HttpPostedFileBase fileData) {
            string proc = Path.GetFileName(fileData.FileName);
            return (proc.Split('.'))[0];
        }

    }
}