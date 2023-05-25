using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ders2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using ders2.ViewModels;
//using ders2.Models;

namespace ders2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _prodoctRepository;
        private readonly IMapper _mapper;
        private readonly ShopContext veritabanim;
        public ProductsController(ShopContext context, IMapper mapper)
        {
            this.veritabanim = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var Urunler = veritabanim.Products.ToList();
            // var Urunler = _prodoctRepository.TumUrunler();
            // return View(Urunler);
            return View(_mapper.Map<List<ProductViewModel>>(Urunler));
        }
        public IActionResult Remove(int id)
        {
            var silinecekurun = veritabanim.Products.Find(id);
            veritabanim.Products.Remove(silinecekurun);
            veritabanim.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Dictionary<string, int> Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Data="Sarı",Value="Sarı"},
                new (){Data="Kırmızı",Value="Kırmızı"},
                new (){Data="Mavi",Value="Mavi"},
                new (){Data="Bordo",Value="Bordo"},
                new (){Data="Beyaz",Value="Beyaz"},
                new (){Data="Turuncu",Value="Turuncu"},
                new (){Data="Kahverengi",Value="Kahverengi"},
                new (){Data="Siyah",Value="Siyah"}
            }, "Value", "Data");
            ViewBag.Expire = Expire;
            // ViewBag.Expire=new List<int>(){1,2,3,6};
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel urun)
        {
            if (ModelState.IsValid)
            {
                veritabanim.Products.Add(_mapper.Map<Product>(urun));
                veritabanim.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                 Dictionary<string, int> Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Data="Sarı",Value="Sarı"},
                new (){Data="Kırmızı",Value="Kırmızı"},
                new (){Data="Mavi",Value="Mavi"},
                new (){Data="Bordo",Value="Bordo"},
                new (){Data="Beyaz",Value="Beyaz"},
                new (){Data="Turuncu",Value="Turuncu"},
                new (){Data="Kahverengi",Value="Kahverengi"},
                new (){Data="Siyah",Value="Siyah"}
            }, "Value", "Data");
            ViewBag.Expire = Expire;
                return View();
            }

        }


        // public IActionResult Add(string Name,decimal Price,int Stock)
        // {
        //     // var isim=HttpContext.Request.Form["Name"].ToString();
        //     // var fiyat=decimal.Parse(HttpContext.Request.Form["Price"].ToString());
        //     // var stok=int.Parse(HttpContext.Request.Form["Stock"].ToString());
        //      Product urun=new Product{Name=Name,Price=Price,Stock=Stock};
        //     // Product urun=new Product();
        //     // urun.Name=Name;
        //     // urun.Price=Price;
        //     // urun.Stock=Stock;
        //     context.Products.Add(urun);
        //     context.SaveChanges();
        //     return RedirectToAction("Index");
        // }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var gelenUrun = veritabanim.Products.Find(id);
            Dictionary<string, int> Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12},

            };
            ViewBag.Expire = Expire;
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new (){Data="Sarı",Value="Sarı"},
                new (){Data="Kırmızı",Value="Kırmızı"},
                new (){Data="Mavi",Value="Mavi"},
                new (){Data="Bordo",Value="Bordo"},
                new (){Data="Beyaz",Value="Beyaz"},
                new (){Data="Turuncu",Value="Turuncu"},
                new (){Data="Kahverengi",Value="Kahverengi"},
                new (){Data="Siyah",Value="Siyah"}
            }, "Value", "Data", gelenUrun.Color);

            return View(gelenUrun);
        }
        [HttpPost]
        public IActionResult Update(Product guncelUrun)
        {

            veritabanim.Products.Update(guncelUrun);
            veritabanim.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}