using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Component
{
    public class MenuViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private Context con;
        public MenuViewComponent(Context con)
        {
            this.con = con;
        }

        public IEnumerable<Menu> GetMenus()
        {
            return con.Menus.Where(x => x.AktifPasif == true).ToList();
        }
        public IViewComponentResult Invoke()
        {
            var f = GetMenus();
            return View(f);
        }
    }
}
