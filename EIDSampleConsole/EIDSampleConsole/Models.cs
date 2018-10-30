using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIDSampleConsole
{
    public class EIDModel
    {
        public static string tempFolder = System.IO.Path.GetTempPath() + @"EID\";
        public bool HasData { get; set; }
        public string EIDNumber { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Pobox { get; set; }
        public string Emirate { get; set; }
        public string City { get; set; }
        public string CityID { get; set; }
        public string Area { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public string SponsorType { get; set; }
        public string ResidencyType { get; set; }
        public string DOB { get; set; }
        public string ResidencyExpiry { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Nationality { get; set; }
        public string NationalityID { get; set; }
        public string PassportNumber { get; set; }
        public string SponsorNumber { get; set; }
        public string SponsorName { get; set; }
        public string CompanyName { get; set; }
        public string ResidencyNumber { get; set; }
        public string PhotoPath { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Signature { get; set; }

    }
}
