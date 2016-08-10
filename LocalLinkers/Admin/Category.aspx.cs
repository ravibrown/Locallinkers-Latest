using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;
using System.IO;
using System.Data;
using System.Web.Services;

namespace LocalLinkers.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        public static Int64 TotalRecords = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                BindCategories();
                GetTotalRecords();

                drpCategory.Items.Clear();
                drpCategory.Items.Add(new ListItem("Select", "0"));
                fill_drpCategory(drpCategory);
            }
        }

        private void fill_drpCategory(DropDownList ddl)
        {
            List<ClsCategory> lst_cat = new List<ClsCategory>();
            ClsCategory obj = new ClsCategory();
            
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsCategory.BooleanValues.Approved;
            lst_cat = obj.GetAll();
            foreach (ClsCategory c in lst_cat)
            {
                ddl.Items.Add(new ListItem(c.Name, c.Id.ToString()));
            }
            
        }

        public void GetTotalRecords()
        {
            if (Request.QueryString["Type"] != null)
            {
                ClsSubCategory obj = new ClsSubCategory();
                obj.IsDeleted = false;
                TotalRecords = obj.GetTotalRecords();
            }
            else
            {
                ClsCategory obj = new ClsCategory();
                obj.IsDeleted = false;
                TotalRecords = obj.GetTotalRecords();
            }
        }
        public void BindCategories()
        {
            if (Request.QueryString["Type"] != null)
            {
                ClsSubCategory obj = new ClsSubCategory();
                obj.IsDeleted = false;
                rptCategories.DataSource = obj.GetAll();
                rptCategories.DataBind();
                thImage.Visible = false;
            }
            else
            {
                ClsCategory obj = new ClsCategory();
                obj.IsDeleted = false;
                rptCategories.DataSource = obj.GetAll();
                rptCategories.DataBind();
                thCategoryName.Visible = false;
            }
        }

        protected void rptCategories_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (Request.QueryString["Type"] == null)
                {
                    System.Web.UI.HtmlControls.HtmlTableCell tdValue2 = (System.Web.UI.HtmlControls.HtmlTableCell)e.Item.FindControl("tdCategoryName");
                    tdValue2.Visible = false;
                }
                else
                {
                    System.Web.UI.HtmlControls.HtmlTableCell tdValue1 = (System.Web.UI.HtmlControls.HtmlTableCell)e.Item.FindControl("tdImage");
                    tdValue1.Visible = false;
                }
            }
        }
        protected void btnCategory_Click(object sender, EventArgs e)
        {
            ClsCategory obj = new ClsCategory();
            string uploadfilename = "";
            string path = "";

            if (hdnCategoryId.Value != "")
            {
                obj.Id = Convert.ToInt64(hdnCategoryId.Value);
                obj.GetRecord();
                if (obj.DataRecieved)
                {
                    if (fileCatgoryImage.HasFile)
                    {
                        path = Server.MapPath(ClsCommon.CategoryImagesPath) + obj.Image;
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                }
            }

            obj.Name = txtname.Text;
            obj.Description = txtDescription.Text;
            obj.ButtonTitle = txtButtonTitle.Text;
            obj.UserMessage = txtUserMessage.Text;
            if (fileCatgoryImage.HasFile)
            {
                string[] arr = fileCatgoryImage.PostedFile.FileName.Split('.');

                string file_ext = arr[1].ToLower();

                if (file_ext == "jpeg" || file_ext == "jpg" || file_ext == "png")
                {
                    uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                    uploadfilename = uploadfilename + "." + file_ext;
                    obj.Image = uploadfilename;
                    fileCatgoryImage.SaveAs(Server.MapPath(ClsCommon.CategoryImagesPath) + uploadfilename);
                }
                else
                {
                    uploadfilename = "no-image-icon.png";
                    obj.Image = uploadfilename;
                }
            }

            if (chkCategory.Checked)
            {
                obj.IsApprovedByAdmin = true;
            }
            else
            {
                obj.IsApprovedByAdmin = false;
            }
           
            if (hdnCategoryId.Value == "")
            {
                ClsCategory objcat = new ClsCategory();
                if (txtname.Text != "")
                {
                    objcat.Name = txtname.Text;
                    objcat.IsDeleted = false;
                    objcat.GetRecord();
                    if (!objcat.DataRecieved)
                    {
                        obj.Add();
                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                    else
                    {
                        lblSuccessMsg.Text = "Already Exist";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                }
            }
            else
            {
                obj.Edit();
                lblSuccessMsg.Text = "Update Successfully";
                alertSuccess.Style.Add("display", "block !important");
            }
            ResetAll();
            BindCategories();
        }

        protected void btnSubCategory_Click(object sender, EventArgs e)
        {
            ClsSubCategory obj = new ClsSubCategory();
            obj.Name = txtSubCategoryName.Text;
            obj.Description = txtSubCategoryDecs.Text;
            obj.CategoryId = Convert.ToInt64(drpCategory.SelectedItem.Value);

            if (chkSubCategory.Checked)
            {
                obj.IsApprovedByAdmin = true;
            }
            else
            {
                obj.IsApprovedByAdmin = false;
            }

            if (hdnSubCategoryId.Value == "")
            {
                ClsSubCategory objsubcat = new ClsSubCategory();
                if (txtSubCategoryName.Text != "")
                {
                    objsubcat.Name = txtSubCategoryName.Text;
                    objsubcat.IsDeleted = false;
                    objsubcat.CategoryId = Convert.ToInt64(drpCategory.SelectedItem.Value);
                    objsubcat.GetRecord();
                    if (!objsubcat.DataRecieved)
                    {
                        obj.Add();
                        lblSuccessMsg.Text = "Add Successfully";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                    else
                    {
                        lblSuccessMsg.Text = "Already exist";
                        alertSuccess.Style.Add("display", "block !important");
                    }
                }
            }
            else
            {
                obj.Id = Convert.ToInt64(hdnSubCategoryId.Value);
                obj.Edit();
                lblSuccessMsg.Text = "Update Successfully";
                alertSuccess.Style.Add("display", "block !important");
            }
            ResetAll();
            BindCategories();
        }

        [WebMethod]
        public static string DeleteCategory(int id)
        {
            string result = "";
            if(id > 0)
            {
                ClsCategory cat = new ClsCategory();
                cat.Id = id;
                cat.IsDeleted = false;
                cat.GetRecord();
                if(cat.DataRecieved)
                {
                    cat.IsDeleted = true;
                    cat.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }

        [WebMethod]
        public static string DeleteSubCategory(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsSubCategory cat = new ClsSubCategory();
                cat.Id = id;
                cat.IsDeleted = false;
                cat.GetRecord();
                if (cat.DataRecieved)
                {
                    cat.IsDeleted = true;
                    cat.Edit();
                    result = "Delete Successfully";
                }
            }
            return result;
        }

        public void ResetAll()
        {
            txtDescription.Text = "";
            txtname.Text = "";
            txtUserMessage.Text = "";
            txtButtonTitle.Text = "";
            txtSubCategoryDecs.Text = "";
            txtSubCategoryName.Text = "";
            chkCategory.Checked = false;
            chkSubCategory.Checked = false;
            hdnCategoryId.Value = "";
            hdnSubCategoryId.Value = "";
        }
    }
}