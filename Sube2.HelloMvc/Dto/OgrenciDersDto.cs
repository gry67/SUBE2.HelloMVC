using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Dto
{
    public class OgrenciDersDto
    {
        public Ogrenci ogrenci { get; set; }
        public List<Ders> dersler {get; set;}
    }
}