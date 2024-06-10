using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.ViewModels;

namespace Sube2.HelloMvc.Controllers
{
    public class DersController : Controller
    {
        
         public IActionResult Index()
        {
            IEnumerable<Ders> lst = null;
            using (var c = new OkulDbContext())
            {
                lst = c.Dersler.ToList();
               
            }
            return View(lst);
        }


        public ViewResult DersEkle()
        {
            return View();
        }

        public ViewResult DersEkle(Ders ders)
        {
           if (ders!=null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Dersler.Add(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ViewResult EditDers(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ders = ctx.Dersler.Find(id);
                return View(ders);
            }
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders!=null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ders).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");   
        }
        
        [HttpGet]
        public IActionResult DeleteDers(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Dersler.Remove(ctx.Dersler.Find(id));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

