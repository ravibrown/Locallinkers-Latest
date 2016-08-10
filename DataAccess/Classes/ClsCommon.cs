using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace DataAccess.Classes
{
    public class ClsCommon
    {
        #region "Enums"
        public enum Template
        {
            Ladybird = 1,
            Lambkin = 2,
            Paramour = 3,
            Honeydew = 4
        }

        #endregion

        #region "Properties"
        public static int CouponImagesLimit = 4;
        public static int ProductImagesLimit = 4;
        public static int BusinessImagesLimit = 5;
        public static int TemplateImagesLimit = 5;
        public static int TemplateSliderLimit = 5;
        public static int TemplateGalleryLimit = 8;
        public static int TemplateServicesLimit = 8;


        public static string IphoneAppUrl = "https://itunes.apple.com/us/app/local-linkers/id1098179119?ls=1&mt=8";
        public static string AndroidAppUrl = "https://play.google.com/store/apps/details?id=com.hbs.hashbrownsys.locallinkers";
        public static string SubjectSubscribe = "Subscribed For Newsletter";
        public static string SubjectContactUs = "Contact Us";
        public static string HomeSliderImagesPath = "/Admin/HomeSliderImages/";
        public static string CouponImagesPath = "/Admin/CouponImages/";
        public static string ProductImagesPath = "/Admin/ProductImages/";
        public static string BusinessImagesPath = "/Admin/BusinessImages/";
        public static string TemplateImagesPath = "/Admin/TemplateImages/";
        public static string TemplateAboutUsImagesPath = "/Admin/TemplateAboutUsImages/";
        public static string TemplateSliderImagesPath = "/Admin/TemplateSliderImages/";
        public static string TemplateGalleryImagesPath = "/Admin/TemplateGalleryImages/";
        public static string PortFolioImagesPath = "/Admin/PortFolioImages/";
        public static string CategoryImagesPath = "/Admin/CategoryImages/";
        public static string UserImagesPath = "/UserImages/";
        public static string UserImagesThumnailPath = "/UserImages/Thumbnail";
        public static string NoImageIcon = "/Admin/Images/no-image-icon.png";
        public static string SignUpMessage = "Welcome to local linkers, your otp is ##OTP##. Enjoy lucrative offers around your city. Thanks for being part of locallinkers.com. In case of queries reach us at 09219999000 or email us at contact@locallinkers.com";
        public static string VerifiedMessage = "Welcome to Local Linkers. You have been credited ten points to buy coupons on the Local Linkers platform. We hope you shall enjoy your stay with us.";
        public static string FromEmail = ConfigurationManager.AppSettings["FromEmail"].ToString();
        public static string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();
        public static string CouponVerifyMessage = "Congratulations on availing ##CouponTitle## at ##BusinessName##. We hope you enjoy the deal, if you have any questions, complaint or feedback call us at +919219999000 or drop us an email at contact@locallinkers.com";
        public static string CouponPurchaseMessage = "Congratulations for purchasing ##CouponTitle## at ##BusinessName##. Your code for redeeming the deal is ##CouponCode##.";
        public static string EmailRegisterSubject = "Local Linkers Registration";
        public static string EmailResetPassword = "Local Linkers ResetPassword";
        public static string EmailRegisterBodyMessage = "Registered Succesfully";
        public static string BusinessBookingSubject = "Local Linkers Business Booking";
        public static string BusinessBookingBodyMessage = "Booking Succesfully";
        public static string ResetPasswordBodyMessage = "Click here for reset password ";
        public static string SiteName = "Local Linkers";
        public static string DefaultLatitude = "30.7333148";
        public static string DefaultLongitude = "76.7794179";
        public static int DefaultSelectedCity = 3;
        public static string DefaultSelectedCityName = "Saharanpur";
        public static string WorkingKey = "FBB36CE6FBF174FE0129F04FC07A7500";
        public static string MerchantKey = "89789";
        //public static string IphonePhoneNumber = "8195905341";
        public static string IphonePhoneNumber = "7696448444";
        public static string AccessCode = "AVKN63DB87AH16NKHA";
        public static string RedirectUrl = "http://locallinkers.com/ccavResponseHandler.aspx";
        public static string CancelUrl = "http://locallinkers.com/Cancel";
        public static string Currency = "INR";
        public static string MerchantCouponMessage = "Congratulations, ##CouponTitle## has been availed by ##UserPhoneNumber##. Kindly login to verify the coupon number ##CouponCode##.";
        public static string BusinessPremiumImagesPath = "/Admin/BusinessPremiumImages/";
        public static string ForgetPasswordMessage = " is your OTP to reset your password.";
        public static string ResendOTPMessage = " is your OTP for verification.";
        public static string BusinessBookingMessage = "An appointment/booking has been made by ##NameAndPhoneNumber## at ##Time##, ##Date##, with the following message, ##Message##";
        public static string BusinessBookingUserMessage = "Thank you for making appointment at ##BusinessName## at ##Time##, ##Date##. For any queries call us at 09219999000 or drop us an email at contact@locallinkers.com ";
        //UserId
        private static Int64 _UserId = 0;
        public static Int64 UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        //RoleId
        private static Int64 _RoleId = 0;
        public static Int64 RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        //UserName
        private static string _UserName = "";
        public static string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        //UserImage
        private static string _UserImage = "";
        public static string UserImage
        {
            get { return _UserImage; }
            set { _UserImage = value; }
        }


        //UserEmail
        private static string _UserEmail = "";
        public static string UserEmail
        {
            get { return _UserEmail; }
            set { _UserEmail = value; }
        }

        //PhoneNumber
        private static string _PhoneNumber = "";
        public static string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        #endregion


        public class LatLong
        {
            public string Latitude { get; set; }
            public string Longitude{ get; set; }
        }
        #region "Common fubnctions"
        public static string NewVerificationCode()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToUInt32(buffer, 6).ToString();
        }
        public static LatLong GetLatLongByCityID(long? cityID)
        {
            if (cityID == 3)//Saharanpur
            {
                return new LatLong { Latitude = "29.9671", Longitude = "77.5510" };
            }
            else if (cityID == 4)//Dehradun
            {
                return new LatLong { Latitude = "30.3165", Longitude = "78.0322" };
            }

            else if (cityID == 5)//Roorkee
            {
                return new LatLong { Latitude = "29.8543", Longitude = "77.8880" };
            }
            else if (cityID == 6)//Haridwar
            {
                return new LatLong { Latitude = "29.9457", Longitude = "78.1642" };
            }
            else if (cityID == 7)//Yamunanagar
            {
                return new LatLong { Latitude = "30.1290", Longitude = "77.2674" };
            }
            else if (cityID == 8)//Meerut
            {
                return new LatLong { Latitude = "28.9845", Longitude = "77.7064" };
            }
            else if (cityID == 9)//Ambala
            {
                return new LatLong { Latitude = "30.3782", Longitude = "76.7767" };
            }
            else
            {
                return new LatLong { Latitude = "29.9671", Longitude = "77.5510" };
            }
        }

        public static string CreateUniqueId()
        {
            string code = string.Empty;
            Guid g;
            g = Guid.NewGuid();
            code = g.ToString().Substring(0, 6);
            return code;
        }

        public static string Encode(string value)
        {
            string encodedValue = string.Empty;
            byte[] encode = new byte[value.Length];
            encode = Encoding.UTF8.GetBytes(value);
            encodedValue = Convert.ToBase64String(encode);
            return encodedValue;
        }
        public static string Decode(string value)
        {
            string decodedValue = string.Empty;
            UTF8Encoding encode = new UTF8Encoding();
            Decoder Decode = encode.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(value);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decodedValue = new String(decoded_char);
            return decodedValue;
        }

        public static bool SetSession()
        {
            HttpContext.Current.Session["UserId"] = UserId;
            HttpContext.Current.Session["UserName"] = UserName;
            HttpContext.Current.Session["RoleId"] = RoleId;
            HttpContext.Current.Session["UserEmail"] = UserEmail;
            HttpContext.Current.Session["UserImage"] = UserImage;
            HttpContext.Current.Session["PhoneNumber"] = PhoneNumber;
            if (HttpContext.Current.Session["UserId"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Session["UserId"] = null;
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["RoleId"] = null;
            HttpContext.Current.Session["UserEmail"] = null;
            HttpContext.Current.Session["UserImage"] = null;
            HttpContext.Current.Session["PhoneNumber"] = null;
            if (HttpContext.Current.Session["UserId"] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetSession()
        {
            bool flag = false;
            if (HttpContext.Current.Session["UserId"] != null)
            {
                if (Convert.ToInt32(HttpContext.Current.Session["UserId"]) != 0)
                {
                    UserId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                    UserName = HttpContext.Current.Session["UserName"].ToString();
                    RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleId"]);
                    UserEmail = HttpContext.Current.Session["UserEmail"].ToString();
                    UserImage = HttpContext.Current.Session["UserImage"].ToString();
                    PhoneNumber = HttpContext.Current.Session["PhoneNumber"].ToString();
                    flag = true;
                }
                else
                {
                    UserId = 0;
                    UserName = "";
                    RoleId = 0;
                    flag = false;
                }
            }
            else
            {
                UserId = 0;
                UserName = "";
                RoleId = 0;
                flag = false;
            }
            return flag;

        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static bool AddImage(string imagetext, string path, string imagename)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)

            bool flag = false;
            try
            {
                byte[] bytes = Convert.FromBase64String(imagetext);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                    path = System.Web.HttpContext.Current.Server.MapPath(path) + imagename;
                    image.Save(path);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public static string SendCodeThroughSms(string PhoneNumber = "", string Message = "", string SenderId = "LLINKR", string UserName = "T1kush", string Password = "9555957777", int routeid = 2, int unicode = 0)
        {
            string result = string.Empty;
            string Url = "";
            try
            {
                Url += "http://hindit.co.in/API/pushsms.aspx?loginID=";
                Url += UserName;
                Url += "&password=" + Password;
                Url += "&mobile=" + PhoneNumber;
                Url += "&text=" + Message;
                Url += "&senderid=" + SenderId;
                Url += "&route_id=" + routeid;
                Url += "&Unicode=" + unicode;
                WebRequest request = WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Stream dataStream = request.GetRequestStream();
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                result = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static bool SendEmail(EmailMessage Message)
        {
            try
            {
                //configure the client
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //create credentials
                NetworkCredential credentials = new NetworkCredential(FromEmail, EmailPassword);
                client.EnableSsl = true;
                client.Credentials = credentials;

                //create message
                var mail = new MailMessage(FromEmail, Message.To);
                mail.IsBodyHtml = true;
                mail.Subject = Message.Subject;
                mail.Body = Message.Message;
    //            ServicePointManager.ServerCertificateValidationCallback =
    //delegate(object s, X509Certificate certificate,
    //         X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //{ return true; };
                client.Send(mail);
                return true;
            }
            catch (Exception ex) { return false; }
        }


        public static bool SendGrid(SendGridMessage myMessage)
        {
            try
            {

                // Create credentials, specifying your user name and password.
                var credentials = new NetworkCredential("azure_00dd706f353fe985b11a73bf863a8a41@azure.com", "CMPQuPIKB45c4np");

                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email.
                // You can also use the **DeliverAsync** method, which returns an awaitable task.
                transportWeb.DeliverAsync(myMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }



        #endregion
    }

    #region "Classes"
    public class EmailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
