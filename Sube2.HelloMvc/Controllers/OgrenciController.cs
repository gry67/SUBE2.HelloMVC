using Microsoft.AspNetCore.Mvc;
using Sube2.HelloMvc.Models;
using Sube2.HelloMvc.Models.ViewModels;

namespace Sube2.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()//action denir
        {
            return View();
        }

        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogr = null;

            Ogretmen ogretmen = new Ogretmen()
            {
                OgretmenId = 1,
                Ad = "Cihan",
                Soyad = "Yetisken"
            };

            if (id == 1)
            {
                ogr = new Ogrenci();
                ogr.Ad = "Ali";
                ogr.Soyad = "Veli";
                ogr.Numara = 123;
            }
            else if (id == 2)
            {
                ogr = new Ogrenci
                { Ad = "Ahmet", Soyad = "Mehmet", Numara = 456 };
            }

            ViewData["ogrenci"] = ogr;
            ViewBag.student = ogr;
            ViewBag.hoca = ogretmen;

            Ders ders = new Ders()
            {
                DersId = 1,
                DersAd = "Internet Programcılığı",
                Kredi = 6
            };

            OgrViewModel vm = new OgrViewModel();
            vm.Ogretmen = ogretmen;
            vm.Ogrenci = ogr;
            vm.Ders = ders; 

            return View(vm);
        }

        public ViewResult OgrenciListe()
        {
            var lst = new List<Ogrenci>()
            {
                new Ogrenci {Ad = "Ali", Soyad = "Veli", Numara =123 },
                new Ogrenci {Ad = "Ahmet", Soyad = "Mehmet", Numara =456 }
            };

            return View(lst);

        }

        public ViewResult OgrenciIslemleri(int ogrenciId){

            return View();
        }
    }

    
}

//html css js bootstrap çıkacak 1-2 soru çıkacak
//Kolleksiyonlar jenerik yapılar, jenerik kısıtlayıcılar
//webin çalışma mantığı ile ilgili
//routing kavramını çöz
//Controllerlar action metodlar model/viewModellar ve viewler Razor
//mvc projesinin klasör yapısına hakim ol appsettings program.cs  falan hepsini bil

//viewData, viewBag, viewModel
