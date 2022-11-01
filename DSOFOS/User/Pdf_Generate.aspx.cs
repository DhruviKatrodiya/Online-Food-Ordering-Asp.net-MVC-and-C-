using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace DSOFOS.Views
{
    public partial class Pdf_Generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string OrderId=Session["OrderId"].ToString();
            Label1.Text = OrderId;
            findorderdate(Label2.Text);
            string Address = Session["Address"].ToString();
            Label3.Text = Address;
            showgrid(Label1.Text);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exportPdf();
        }
        private void exportPdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw=new StringWriter();
            HtmlTextWriter hw= new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr=new StringReader(sw.ToString());
            Document pdfDoc= new Document(PageSize.A4,10f,10f,100f,0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        
        
        }

        private void findorderdate(string OrderId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand("Select * from Order where OrderId='"+ Label1.Text+"'");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                Label2.Text=ds.Tables[0].Rows[0]["CreatedAt"].ToString();

            }
            con.Close();
            

        }
        private void showgrid(string OrderId)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("itemid");
            dt.Columns.Add("itemname");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("amount");
            dt.Columns.Add("Bill");
            SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=DSOFOSDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand("Select * from Order where OrderId='" + Label1.Text + "'");
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;

            while (i < totalrows)
            {
                dr = dt.NewRow();
                dr["sno"] = ds.Tables[0].Rows[i]["sno"].ToString();
                dr["itemid"] = ds.Tables[0].Rows[i]["itemid"].ToString();
                dr["itemname"] = ds.Tables[0].Rows[i]["itemname"].ToString();
                dr["Quantity"] = ds.Tables[0].Rows[i]["Quantity"].ToString();
                dr["amount"] = ds.Tables[0].Rows[i]["amount"].ToString();

                int amount = Convert.ToInt32(ds.Tables[0].Rows[i]["amount"].ToString());
                int Quantity = Convert.ToInt16(ds.Tables[0].Rows[i]["Quantity"].ToString());
                int Bill = amount * Quantity;
                dr["Bill"] = Bill;
                grandtotal = grandtotal + Bill;
                dt.Rows.Add(dr);
                i = i + 1;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label4.Text = grandtotal.ToString();
        }

          
   

    }
}