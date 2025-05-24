using IBBA.helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBBA.Pages
{
	public partial class Player : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.Files.Count > 0 && Request.Files["fileUpload"] != null)
                {
                    var file = Request.Files["fileUpload"];

                    if (file != null && file.ContentLength > 0)
                    {
                        try
                        {
                            string tzValue = Session["tz"]?.ToString();
                            if (string.IsNullOrEmpty(tzValue))
                            {
                                Response.Redirect("Login.aspx");
                                return;
                            }

                            // שומר את הקובץ עם שם לפי ת"ז + סיומת המקורית
                            string fileName = tzValue + System.IO.Path.GetExtension(file.FileName);
                            string savePath = Server.MapPath("~/Images/") + fileName;

                            file.SaveAs(savePath);

                            // עדכון במסד הנתונים - שומר את שם הקובץ כולל הסיומת
                            string query = $"UPDATE Player SET img = '{fileName}' WHERE tz = '{tzValue}'";
                            DbHelper.SQL_Update(query);

                            lblMessage.InnerText = "התמונה הועלתה בהצלחה.";
                            imgPlayer.Src = "../Images/" + fileName;
                        }
                        catch (Exception ex)
                        {
                            lblMessage.InnerText = "שגיאה: " + ex.Message;
                        }
                    }
                    else
                    {
                        lblMessage.InnerText = "יש לבחור קובץ תמונה.";
                    }
                }
            }
            else
            {
                // טעינת נתוני השחקן בהתחלה (כבר יש לך את זה)
                if (Session["tz"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                string tzValue = Session["tz"].ToString();
                DataTable dt = DbHelper.SQL_Select($"SELECT * FROM Player WHERE tz = '{tzValue}'");

                if (dt.Rows.Count == 0)
                {
                    Response.Write("<script>alert('שחקן לא נמצא');</script>");
                    return;
                }

                var row = dt.Rows[0];

                name.InnerText = row["name"].ToString();
                age.InnerText = row["age"].ToString();
                number.InnerText = row["number"].ToString();
                position.InnerText = row["position"].ToString();
                team.InnerText = row["team"].ToString();
                gender.InnerText = row["gender"].ToString();
                tz.InnerText = row["tz"].ToString();

                string imgName = row["img"]?.ToString();
                if (!string.IsNullOrEmpty(imgName))
                    imgPlayer.Src = "../Images/" + imgName;
                else
                    imgPlayer.Src = "../Images/noam.jpg";
            }
        }



    }
}