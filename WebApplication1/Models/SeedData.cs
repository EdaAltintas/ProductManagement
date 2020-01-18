using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product { ProductName = "Kalem", ProductDesc = "mikemmel kalem", Price = 10, Stock = 100, category = new Category() { CategoryName = "Dolma kalem" } },
                    new Product { ProductName = "Defter", ProductDesc = "mikemmel defter", Price = 25, Stock = 350, category = new Category() { CategoryName = "Telli defter" } },
                    new Product { ProductName = "Kitap", ProductDesc = "mikemmel kitap", Price = 20, Stock = 180, category = new Category() { CategoryName = "Roman" } },
                    new Product { ProductName = "Oppo A9 2020 128GB Uzay Moru Akıllı Telefon", ProductDesc = " OPPO A9 2020 (A9) tek bir akıllı telefonda \n beş farklı kamera modu sunar.48MP arka ana lens, maksimum düzeyde fotoğraf çözünürlüğü sağlar. Ultra Geniş 119° arka lens ile panoramik görüntüler yakalarsınız", Price = 2449, Stock = 100, category = new Category() { CategoryName = "Telefon" } },
                    new Product { ProductName = "Sony Kulaklık", ProductDesc = " Sony MDR-RF895RK TV Kablosuz Kulaklık", Price = 600, Stock = 100, category = new Category() { CategoryName = "Kulaklık" } },
                    new Product { ProductName = "HP Laptop", ProductDesc = "HP ENVY 13-AQ1001NT 8KH53EA Intel i5-10210U 8 GB DDR4 RAM 512 GB SSD NVIDIA MX250 2GB 13.3' FULL HD WIN10H SILVER NOTEBOOK", Price = 7319, Stock = 200, category = new Category() { CategoryName = "Bilgisayar" } }
                    );
                context.SaveChanges();
            }
        }
    }
}
