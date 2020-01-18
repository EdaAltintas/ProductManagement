using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Menu
    {
        public int menuID { get; set; }
        public string menuAdi { get; set; }
        public string desc { get; set; }
        public int UstMenuID { get; set; }
        public int SiraNo { get; set; }
        public bool AktifPasif { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
