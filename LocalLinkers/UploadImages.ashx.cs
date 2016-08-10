using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LocalLinkers
{
    /// <summary>
    /// Summary description for UploadImages
    /// </summary>
    public class UploadImages : IHttpHandler
    {

        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";

        //    string dirFullPath = HttpContext.Current.Server.MapPath("~/Admin/CouponImages/");
        //    string[] files;
        //    int numFiles;
        //    files = System.IO.Directory.GetFiles(dirFullPath);
        //    numFiles = files.Length;
        //    numFiles = numFiles + 1;

        //    string str_image = "";

        //    foreach (string s in context.Request.Files)
        //    {
        //        HttpPostedFile file = context.Request.Files[s];
        //        string fileName = file.FileName;
        //        string fileExtension = file.ContentType;

        //        if (!string.IsNullOrEmpty(fileName))
        //        {
        //            fileExtension = Path.GetExtension(fileName);
        //            str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
        //            string pathToSave = HttpContext.Current.Server.MapPath("~/Admin/CouponImages/") + str_image;
        //            file.SaveAs(pathToSave);
        //        }
        //    }
        //    context.Response.Write(str_image);
        //}

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string str_image = "";
            string result = "";
            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
                string fileName = file.FileName;
                string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    //fileExtension = Path.GetExtension(fileName);
                    str_image = CreateFileName(file.FileName);
                    string pathToSave = "";
                    if(type=="Coupons")
                    {
                        pathToSave = HttpContext.Current.Server.MapPath(ClsCommon.CouponImagesPath);
                    }
                    else if (type == "Products")
                    {
                        pathToSave = HttpContext.Current.Server.MapPath(ClsCommon.ProductImagesPath);
                    }
                    else if(type=="Business")
                    {
                         pathToSave = HttpContext.Current.Server.MapPath(ClsCommon.BusinessImagesPath);
                    }
                    else if (type == "Template")
                    {
                        pathToSave = HttpContext.Current.Server.MapPath(ClsCommon.TemplateImagesPath);
                    }
                    string combinePath = Path.Combine(pathToSave, str_image);
                    if (CreateFolderIfNeeded(pathToSave))
                    {
                        file.SaveAs(combinePath);
                    }
                }
                result = str_image + "," + file.FileName;
            }
            context.Response.Write(result);
        }

        public string CreateFileName(string path)
        {

            string[] file = path.Split('.');
            string givenName = DateTime.Now.ToString("hh.mm.ss.ffffff").Replace(".", "") + "." + file[1];
            return givenName;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }
    }
}