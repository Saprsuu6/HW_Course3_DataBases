using System;
using System.Xml.Linq;

namespace Client
{
    internal class Check
    {
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string ClientSurename { get; set; }
        public string SellerName { get; set; }
        public string SellerSurename { get; set; }
        public string FridgeName { get; set; }
        public int FridgePrice { get; set; }

        public void SaveInXml()
        {
            string path = Date.ToShortDateString() + "Check.xml";
            path = path.Replace('/', '_');

            XDocument xdoc = new XDocument(new XElement("Checks",
                new XElement("Date", Date.ToString()),
                new XElement("ClientName", ClientName),
                new XElement("ClientSurename", ClientSurename),
                new XElement("SellerName", SellerName),
                new XElement("SellerSurename", SellerSurename),
                new XElement("FridgeName", FridgeName),
                new XElement("FridgePrice", FridgePrice)));
            xdoc.Save(path);
        }
    }
}
