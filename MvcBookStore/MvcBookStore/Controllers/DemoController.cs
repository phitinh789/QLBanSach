using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;

namespace MvcBookStore.Controllers
{
    public class DemoController : Controller
    {
        dbQLBanSachDataContext db = new dbQLBanSachDataContext();
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sach()
        {
            return View(db.SACHes.ToList());
        }
    }
}