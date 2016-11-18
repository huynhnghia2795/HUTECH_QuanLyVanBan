using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.DanhMucID = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.UpdatedDate), "DanhMucID", "TenDanhMuc");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(DanhMuc g)
        {
            db.DanhMucs.InsertOnSubmit(g);
            db.SubmitChanges();
            return RedirectToAction("Danhmuc");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DanhMuc danhmuc = db.DanhMucs.SingleOrDefault(n => n.DanhMucID == id);
            if (danhmuc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.UpdatedDate), "DanhMucID", "TenDanhMuc", danhmuc.DanhMucID);
            return View(danhmuc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DanhMuc g)
        {
            UpdateModel(g);
            db.SubmitChanges();
            return RedirectToAction("Danhmuc");
        }
    }
}