using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    public static class XMLTools
    {
        /// <summary>
        /// Finds duplicate values in a specified XML file and for a specified node.
        /// </summary>
        /// 
        /// <param name="XMLFilePath">
        /// The name and path to the xml file to check.
        /// </param>
        /// 
        /// <param name="ParentName">
        /// The name of the parent node containing the element node.
        /// </param>
        /// 
        /// <param name="ElementName">
        /// The name of the element node to check for duplicate values.
        /// </param>
        /// 
        /// <returns>
        /// A list of the duplicate values from the element node.
        /// </returns>
        /// 
        public static object GetDuplicateValues(string XMLFilePath, string ParentName, string ElementName)
        {
            if (File.Exists(XMLFilePath))
            {
                if (!string.IsNullOrEmpty(ParentName))
                {
                    if (!string.IsNullOrEmpty(ElementName))
                    {
                        XDocument xDoc = XDocument.Load(XMLFilePath);

                        var result = (
                                from hit in xDoc.Descendants(ParentName)
                                group hit by new {hit.Element(ElementName).Value}
                                into dupeItems
                                where dupeItems.Count() > 1
                                select new
                                {
                                    dupeItems.Key.Value
                                }
                            ).ToList();

                        return result;
                    }
                }
            }

            return null;
        }
    }
}
