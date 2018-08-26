using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;

using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private SpareParsShopEntities db = new SpareParsShopEntities();

        
        public ActionResult ProductReport()
        {
            
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/ProductReport.rpt")));

            rd.SetDataSource(db.Sales.Select(x=> new
            {
                SalesId = x.SalesId,
                SalesDate = x.SalesDate,
                SalesAmount = x.SalesAmount
            }).ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0,SeekOrigin.Begin);
            return File(stream, "appliction/pdf", "SalesReport.pdf");
        }

        //public ActionResult PurchaseReport()
        //{
        //    var datai = db.Purchases.Select(x => new
        //    {
        //        ReceiptId = x.ReceiptId ?? "No Val",
        //        PurcheseDate =  x.PurcheseDate.ToString() ,
        //        Product = x.Product.ProductName ?? "No Val"
        //    }).ToList();

        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Reports/ProductReport.rpt")));

        //    rd.SetDataSource(datai);
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);
        //    return File(stream, "appliction/pdf", "PurchaseReport.pdf");
        //}
    }
}