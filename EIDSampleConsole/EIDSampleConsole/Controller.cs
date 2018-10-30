using EmiratesId.AE.PublicData;
using EmiratesId.AE.ReadersMgt;
using EmiratesId.AE.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIDSampleConsole
{
    public class Controller
    {
        public static EIDModel CreateFromEIDReader()
        {
            EIDModel model = new EIDModel();
            ReaderManagement readerManager;
            PCSCReader reader;
            try
            {
                //System.Windows.Forms.MessageBox.Show("before reader");
                readerManager = new ReaderManagement();
                readerManager.EstablishContext();
                readerManager.DiscoverReaders();
                //System.Windows.Forms.MessageBox.Show("after reader discover");
                if (readerManager.Readers.Length > 0)
                {
                    reader = readerManager.Readers[0];
                    if (reader.IsConnected())
                    {
                        //System.Windows.Forms.MessageBox.Show("after connection to reader, before getting data");
                        PublicDataFacade pDataFacade = reader.GetPublicDataFacade();
                        CardHolderPublicData pData = pDataFacade.ReadPublicData(true, true, true, true, false);
                        CardHolderPublicDataEx pDataEx = pDataFacade.ReadPublicDataEx(true, false, true, true, false, true, true, true);

                        model.EIDNumber = Utils.ByteArrayToUTF8String(pData.IdNumber);
                        model.Phone = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.ResidentPhoneNumber);
                        model.Mobile = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.MobilePhoneNumber);
                        model.Email = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.Email);
                        model.Pobox = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.POBox);
                        model.Emirate = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.EmirateDescriptionEnglish);
                        model.City = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.CityDescriptionEnglish);
                        model.Area = Utils.ByteArrayToUTF8String(pDataEx.HomeAddress.AreaDescriptionEnglish);

                        model.Sex = Utils.ByteArrayToUTF8String(pData.Sex);
                        model.Occupation = Utils.ByteArrayToUTF8String(pData.Occupation);
                        model.Occupation = Utils.ByteArrayToUTF8String(pDataEx.OccupationEnglish);
                        model.Occupation = Utils.ByteArrayToUTF8String(pDataEx.OccupationArabic);
                        model.Occupation = Utils.ByteArrayToUTF8String(pDataEx.OccupationTypeEnglish);
                        model.Occupation = Utils.ByteArrayToUTF8String(pDataEx.OccupationTypeArabic);

                        model.ResidencyType = Utils.ByteArrayToHex(pData.ResidencyType, "");
                        model.DOB = Utils.ByteArrayToStringDate(pData.DateOfBirth).Replace("/", "-");

                        model.ResidencyExpiry = Utils.ByteArrayToStringDate(pData.ResidencyExpiryDate);
                        model.Name = RemoveComma(Utils.ByteArrayToUTF8String(pData.FullName));
                        model.NameAr = RemoveComma(Utils.ByteArrayToUTF8String(pData.ArabicFullName));

                        model.Title = Utils.ByteArrayToUTF8String(pData.Title);
                        model.TitleAr = Utils.ByteArrayToUTF8String(pData.ArabicTitle);
                        model.NationalityID = (Utils.ByteArrayToUTF8String(pData.Nationality));
                        model.PassportNumber = Utils.ByteArrayToUTF8String(pDataEx.PassportNumber);

                        model.SponsorType = Utils.ByteArrayToHex(pData.SponsorType, "");
                        model.SponsorNumber = Utils.ByteArrayToHex(pData.SponsorNumber, "");
                        model.SponsorName = Utils.ByteArrayToUTF8String(pData.SponsorName);
                        model.CompanyName = Utils.ByteArrayToUTF8String(pDataEx.CompanyNameEnglish);
                        if (pData.ResidencyNumber != null)
                            model.ResidencyNumber = Utils.ByteArrayToUTF8String(pData.ResidencyNumber).Trim();

                        model.PhotoPath = @"C:\Temp\EID_PHO_" + model.EIDNumber.Replace(" ", "").Trim() + ".jpg";
                        model.Photo = pData.Photography;
                        if (pData.Photography != null)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(pData.Photography);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            image.Save(model.PhotoPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }

                        model.Signature = pDataEx.HolderSignatureImage;
                        if (pDataEx.HolderSignatureImage != null)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(pDataEx.HolderSignatureImage);
                            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                            image.Save(@"C:\Temp\EID_SIG_" + model.EIDNumber.Replace(" ", "").Trim() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        model.HasData = true;
                    }

                }

            }
            catch (Exception ex)
            {
                model.HasData = false;
                Console.WriteLine("ERROR: " + ex.Message);
            }
            return model;
        }
        public static string RemoveComma(string value)
        {
            string result = "";
            string[] valuelist = value.Split(new Char[] { ',' });
            foreach (string v in valuelist)
            {
                if (v.Trim().Length > 0)
                    result += v.Trim() + " ";
            }
            return result.Trim();
        }
    }
}
