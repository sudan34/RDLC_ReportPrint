using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace RDLC_ReportPrint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ReportEmployee();
            return View();
        }

        ReportDataSet1 ds = new ReportDataSet1();
        public ActionResult ReportEmployee() 
        
        { 
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(15000);
            reportViewer.Height = Unit.Percentage(15000);
            var connectionString = "Data Source=.,Initial Catalog = LearnSql_DB;Integrated Security=True";
            SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM emp_table", conx);
            adp.Fill(ds, ds.emp_table.TableName);
            reportViewer.LocalReport.ReportPath = Server.MapPath(@"/MyReport.rdlc");
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet1", ds.Tables[0]));
            ViewBag.reportViewer = reportViewer;
            return View();

        }

    }
}