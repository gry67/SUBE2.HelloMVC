using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Dto;
using Sube2.HelloMvc.Models;


namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciDersController : Controller
    {
        private readonly OkulDbContext _context;

        public OgrenciDersController(OkulDbContext context)
        {
            _context = context;
        }


        //Öğrenci ders seçimi için
        public IActionResult Index(int id)
        {
            // İlgili öğrenciyi bul
            var ogr = _context.Ogrenciler.Find(id);
            if (ogr == null)
            {
                return NotFound(); 
            }
            List<Ders> dersler = _context.Dersler.ToList();


            return View(new OgrenciDersDto{ogrenci= ogr,dersler= dersler});
        }

        [HttpPost]
        public IActionResult DersSec(int ogrenciId, int dersId) 
        {
        // İlgili öğrenciyi ve dersi bul
        var ogr = _context.Ogrenciler.Find(ogrenciId);
        var ders = _context.Dersler.Find(dersId);
        if (ogr == null || ders == null)
        {
           return NotFound(); 
        }   

        // Öğrenciye dersi ata ve değişiklikleri kaydet
        ogr.Dersler.Add(new OgrenciDers { DersId = dersId });
        _context.SaveChanges();

         return RedirectToAction("Index");
        }   

        public IActionResult SecilenDersleriGoster(int ogrenciId)
        {
            var secilenDersler = _context.OgrencilerDersler
                                    .Where(od => od.OgrenciId == ogrenciId)
                                    .Select(od => od.Ders)
                                    .ToList();
            var model = new     
            {
             Ogrenciid = ogrenciId,
              dersler = secilenDersler
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DersiBirak(int ogrenciId, int dersId)
        {
         // Öğrencinin seçtiği dersi bırak
         var ogrenciDers = _context.OgrencilerDersler
                                     .SingleOrDefault(od => od.OgrenciId == ogrenciId && od.DersId == dersId);

         if (ogrenciDers == null)
         {
                return NotFound();
         }

         _context.OgrencilerDersler.Remove(ogrenciDers);
         _context.SaveChanges();

        return RedirectToAction("SecilenDersleriGoster", new { ogrenciId = ogrenciId });
        }           
    }
}
