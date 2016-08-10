﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;
using DataAccess.Classes;
using System.Net.Mail;


    public partial class SubmitData : System.Web.UI.Page
    {
        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = ClsCommon.WorkingKey;//put in the 32bit alpha numeric key in the quotes provided here 	
        string ccaRequest = "";
        public string strEncRequest="";
        public string strAccessCode =ClsCommon.AccessCode;// put the access key in the quotes provided here.
         protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {

                foreach (string name in Request.Form)
                {
                    if (name != null)
                    {
                        if (!name.StartsWith("_"))
                        {
                            if (name == "order_id")
                            {
                                string NewUniqueId = ClsCommon.NewVerificationCode().ToString().Substring(0, 6);
                                ccaRequest = ccaRequest + name + "=" + NewUniqueId + "&";
                            }
                            else
                            {
                                ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";
                            }
                            /* Response.Write(name + "=" + Request.Form[name]);
                              Response.Write("</br>");*/
                        }
                    }
                }
               
                //foreach (string name in Request.QueryString)
                //{
                //    if (name != null)
                //    {
                //        if (!name.StartsWith("_"))
                //        {
                //            ccaRequest = ccaRequest + name + "=" + Request.QueryString[name] + "&";
                //            /* Response.Write(name + "=" + Request.Form[name]);
                //              Response.Write("</br>");*/
                //        }
                //    }
                //}
                strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
            }
        }
    }

