using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace OnlineCinemaProject.Controllers
{
    public class RestoreController : Controller
    {
        //
        // GET: /Restore/
        public ActionResult Index()
        {
            string constring = "server=localhost;User Id=root;password=22312tuit;database=online-cinema;";
            string file = "D:\\online-cinema.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }
            return View();
        }

      
    }
}
