using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLVanBan.Models;

namespace WebQLVanBan.Controllers
{
    public class QLVanBanController : Controller
    {
        // GET: QLVanBan
        DataClassesQLVanBanDataContext db = new DataClassesQLVanBanDataContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Danhmuc()
        {
            return View(db.DanhMucs.ToList());
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DanhMuc g = db.DanhMucs.SingleOrDefault(n => n.DanhMucID == id);
            ViewBag.DanhMucID = g.DanhMucID;
            if (g == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(g);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            DanhMuc g = db.DanhMucs.SingleOrDefault(n => n.DanhMucID == id);
            ViewBag.DanhMucID = g.DanhMucID;
            if (g == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DanhMucs.DeleteOnSubmit(g);
            db.SubmitChanges();
            return RedirectToAction("Danhmuc");

        }
    }
}