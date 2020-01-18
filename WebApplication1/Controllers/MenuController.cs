using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {
        private Context con;
        public readonly IHostEnvironment HostEnvironment;
        public MenuController(Context con, IHostEnvironment hostEnvironment)
        {
            this.con = con;
            HostEnvironment = hostEnvironment;
        }
        // GET: Menu
        public ActionResult Index()
        {
            var a = con.Menus.ToList();
            return View(a);
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            return View(con.Menus.Where(c => c.menuID == id).FirstOrDefault());
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.iconlar = new SelectList(con.Menus, "menuID", "desc");
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu mn,IFormCollection collection)
        {
            try
            {
                Menu m = new Menu()
                {
                    menuAdi = mn.menuAdi,
                    SiraNo = mn.SiraNo,
                    UstMenuID = mn.UstMenuID,
                    AktifPasif = mn.AktifPasif,
                    Controller = mn.Controller,
                    Action = mn.Action,
                    desc = mn.desc
                };
                con.Menus.Add(m);
                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            var a = con.Menus.Find(id);
            ViewBag.iconlar = new SelectList(con.Menus, "menuID", "desc");
            return View(a);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu mn,int id, IFormCollection collection)
        {
            try
            {
                Menu m = new Menu()
                {
                    menuID=id,
                    menuAdi = mn.menuAdi,
                    SiraNo = mn.SiraNo,
                    UstMenuID = mn.UstMenuID,
                    AktifPasif = mn.AktifPasif,
                    Controller = mn.Controller,
                    Action = mn.Action,
                    desc = mn.desc
                };
                con.Entry(m).State = EntityState.Modified;
                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}