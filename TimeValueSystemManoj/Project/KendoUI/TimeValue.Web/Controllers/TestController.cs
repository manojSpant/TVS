using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeValueProjects.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            DataTable dt = GetTable();

            dynamic data = from dr in GetTable().AsEnumerable()
                           where dr.Field<int>("Dosage") == 25
                           select dr.Field<string>("Drug");


            var d = data;


            // Select more than one fields.
            var Fields = from dr in GetTable().AsEnumerable()
                         select new
                         {
                             Dosage = String.Concat(dr.Field<int>("Dosage").ToString(), "1-1", dr.Field<string>("Patient")),
                             Drug = dr.Field<string>("Drug") + "-" + dr.Field<string>("Patient")
                         };

            data = Fields;


            // 

            return View("KendoUIControls");
        }

        public DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
    }
}