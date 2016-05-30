using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace OnlineCinemaProject.Controllers
{
    public class RestoreController : Controller
    {

        // GET: /Restore/
        public ActionResult Index(string url)
        {
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(url);
                        conn.Close();
                    }
                }
            }

            return RedirectToAction("Index", "Backup");
        }

        public ActionResult Zip(string urlZip)
        {
            string extractPath = ConfigurationManager.AppSettings["startPath"].ToString();
            ZipFile.ExtractToDirectory(urlZip, extractPath);
            return RedirectToAction("Index", "Backup");
        }


    }
}