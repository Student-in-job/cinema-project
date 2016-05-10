using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using OnlineCinemaProject.Models;

namespace OnlineCinemaProject.Controllers
{
    public class BackupController : Controller
    {
        private readonly OnlineCinemaEntities _db = new OnlineCinemaEntities();
        //
        // GET: /Backup/
        public ActionResult Index()
        {
            var backups = _db.backups.ToList();
            return View(backups);
        }

        public ActionResult Create()
        {
            string constring = "server=localhost;User Id=root;password=22312tuit;Persist Security Info=True;database=online-cinema";
            string file = "D:\\Diplomka\\OnlineCinemaProject\\Backup\\online-cinema.sql";
            string newFileName =
             Path.Combine(
             Path.GetDirectoryName(file)
           , string.Concat(Path.GetFileNameWithoutExtension(file)
                          , DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss")
                          , Path.GetExtension(file)
                          )
           );
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(newFileName);
                        conn.Close();
                    }
                }
            }

            backup backup = new backup
            {
                Name = "backup за "+ DateTime.Now, 
                Date_Backup = DateTime.Now,
                Way = newFileName
            };
            if (ModelState.IsValid)
            {
                _db.backups.Add(backup);
                _db.SaveChanges();
                return RedirectToAction("Index", "Backup");

            }

            return RedirectToAction("Error", "Errors");
            
        }

    }
}
