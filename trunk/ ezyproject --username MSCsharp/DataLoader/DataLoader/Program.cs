using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Smartmail.Toolkit.Extensions;
using System.Globalization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("NZVEHEXT.txt"))
            {
                var data = from line in reader.Lines()
                           let tmpDate = line.Substring(349, 8).Trim()
                           let tmpRegDate = line.Substring(369,8).Trim()
                           select new
                           {
                               Status = line.Substring(0, 1),
                               //ModelVariant = line.Substring(1,15),
                               VehicleId = line.Substring(16, 9),
                               //OwnerTitle = line.Substring(25,6),
                               //OwnerFirstName = line.Substring(31,30),
                               //OwnerLastName =  line.Substring(61,30),
                               //OwnerStreet = line.Substring(91,30),
                               //OwnerTown = line.Substring(121,30),
                               //OwnerHomePhone = line.Substring(151, 4).Trim() + line.Substring(155, 8).Trim(),
                               //OwnerBusinessPhone = line.Substring(163, 4).Trim() + line.Substring(167, 8).Trim(),
                               //OwnerFax = line.Substring(175, 4).Trim() + line.Substring(179, 8).Trim(),
                               //DriverTitle = line.Substring(187, 6).Trim(),
                               //DriverFirstName = line.Substring(193, 30).Trim(),
                               //DriverLastName = line.Substring(223, 30).Trim(),
                               //DriverStreet = line.Substring(253,30),
                               //DriverTown = line.Substring(283,30),
                               //DriverHomePhone = line.Substring(313,4).Trim() + line.Substring(317,8),
                               //DriverBusinessPhone = line.Substring(325,4).Trim() + line.Substring(329,8),
                               //DriverFax = line.Substring(337,4).Trim() + line.Substring(341,8).Trim(),
                               
                               //DateRetailed = ((tmpDate == string.Empty)?string.Empty: DateTime.ParseExact(tmpDate,"yyyymmdd",CultureInfo.InvariantCulture).ToString()),
                               //DealerNum = line.Substring(357,5),
                               //RegNum = line.Substring(362,7),
                               //RegDate = ((tmpRegDate == string.Empty) ? string.Empty : DateTime.ParseExact(tmpRegDate, "yyyymmdd", CultureInfo.InvariantCulture).ToString()),
                               //DomesticVIN = line.Substring(377,17),
                               //VIN = line.Substring(394,17),
                               //OwnerEmail = line.Substring(411,50).Trim(),
                               //DriverEmail = line.Substring(461,50).Trim(),
                               SalesPerson = line.Substring(511)
                           };

                ObjectDumper.Write(data, 1);


            }
        }
    }
}
