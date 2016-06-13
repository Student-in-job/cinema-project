using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
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
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            string file = ConfigurationManager.AppSettings["file"].ToString();
            string startPath = ConfigurationManager.AppSettings["startPath"].ToString();
            string zipPath = ConfigurationManager.AppSettings["zipPath"].ToString();
            string newFileName = Path.Combine(Path.GetDirectoryName(file), string.Concat(Path.GetFileNameWithoutExtension(file)
                          , DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss")
                          , Path.GetExtension(file)
                          ));
            string newZipPath = Path.Combine(Path.GetDirectoryName(zipPath), string.Concat(Path.GetFileNameWithoutExtension(zipPath)
                          , DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss")
                          , Path.GetExtension(zipPath)
                          ));

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

            ZipFile.CreateFromDirectory(startPath, newZipPath);

            backup backup = new backup
            {
                Name = "backup за " + DateTime.Now,
                Date_Backup = DateTime.Now,
                Way = newFileName,
                ZipWay = newZipPath
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