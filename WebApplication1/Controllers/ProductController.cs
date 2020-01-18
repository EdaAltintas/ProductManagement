using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private Context con;
        public readonly IHostEnvironment HostEnvironment;
        public ProductController(Context con,IHostEnvironment hostEnvironment)
        {
            this.con = con;
            HostEnvironment = hostEnvironment;
        }
        // GET: Product
        public ActionResult Index()
        {
            var ff = con.Products.Include(x => x.category).ToList();
            return View(ff);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(con.Products.Include(x => x.category).Where(c => c.Id == id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.kategoriler = new SelectList(con.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel pvm,int id,string productName,string productDesc,int price,int stock,int categoryId,IFormCollection collection)
        {
            try
            {
                string uniqFileName = null;
                if (pvm.Img != null)
                {
                    string uploadsFolder = Path.Combine(HostEnvironment.ContentRootPath, "wwwroot/images");
                    uniqFileName = Guid.NewGuid().ToString() + "_" + pvm.Img.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    pvm.Img.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Product pp = new Product()
                {
                    ProductName = pvm.ProductName,
                    ProductDesc = pvm.ProductDesc,
                    Price = pvm.Price,
                    Stock = pvm.Stock,
                    CategoryId=pvm.CategoryId,
                    Img = uniqFileName
                };
                con.Products.Add(pp);
                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var d= con.Products.Include(x => x.category).Where(c => c.Id == id).FirstOrDefault();
            ViewBag.kategoriler = new SelectList(con.Categories, "Id", "CategoryName");
            return View(d);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,ProductViewModel pvm, IFormCollection collection)
        {
            try
            {
                string uniqFileName = null;
                if (pvm.Img != null)
                {
                    string uploadsFolder = Path.Combine(HostEnvironment.ContentRootPath, "wwwroot/images");
                    uniqFileName = Guid.NewGuid().ToString() + "_" + pvm.Img.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    pvm.Img.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Product pp = new Product()
                {
                    Id = id,
                    ProductName = pvm.ProductName,
                    ProductDesc = pvm.ProductDesc,
                    Price = pvm.Price,
                    Stock = pvm.Stock,
                    CategoryId = pvm.CategoryId,
                    Img = uniqFileName
                };
                con.Entry(pp).State = EntityState.Modified;
                con.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(con.Products.Include(x => x.category).Where(c => c.Id == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var silinecekProduct = con.Products.Find(id);
                con.Products.Remove(silinecekProduct);
                con.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CustomerProductDetail(int id)
        {
            return View(con.Products.Include(x=>x.category).FirstOrDefault(x=>x.Id==id));
        }
    }
}