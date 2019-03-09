using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OrderProcessing.Lib
{
    public class OrderRequest
    {
        private static readonly Regex rxRequestInfo = new Regex(@":\t+(.*)",         RegexOptions.Compiled);
        private static readonly Regex rxProductInfo = new Regex(@"(.*)\t(.*)\t(.*)", RegexOptions.Compiled);

        public static OrderRequest FromEmail(MailMessage email)
        {
            if (email is null)                    throw new ArgumentNullException(nameof(email));
            if (email.Subject != "Order Request") throw new ArgumentException($"Wrong Email Type: {email.Subject}");

            MatchCollection matches = rxRequestInfo.Matches(email.Body);





            OrderRequest request = new OrderRequest
            {

                Company      =                matches[0].Groups[1].Value,
                Orderer      =                matches[1].Groups[1].Value,
                OrderDate    = DateTime.Parse(matches[2].Groups[1].Value),
                Shipper      =                matches[4].Groups[1].Value,
                Freight      =  Decimal.Parse(matches[5].Groups[1].Value)
               


            };
            return request;
        }


        public string                             Company        { get; private set; }
        public string                             Orderer        { get; private set; }
        public DateTime                           OrderDate      { get; private set; }
        public DateTime                           RequiredDate   { get; private set; }
        public string                             Shipper        { get; private set; }
        public decimal                            Freight        { get; private set; }
        public DateTime                           ShipDate       { get; private set; }
        public IReadOnlyCollection<ProductDetail> ProductDetails { get; private set; }

        public class ProductDetail
        {
            internal ProductDetail(string detailLine)
            {
                string[] parts = detailLine.Split('\t');
                Product   =               parts[0];
                ProductID =     int.Parse(parts[1]);
                Quantity  =     int.Parse(parts[2]);
                Discount  = decimal.Parse(parts[3]);
            }

            public string  Product   { get; internal set; }
            public int     ProductID { get; internal set; }
            public int     Quantity  { get; internal set; }
            public decimal Discount  { get; internal set; }
        }

    }
}
