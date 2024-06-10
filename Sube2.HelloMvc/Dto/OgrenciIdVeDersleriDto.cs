using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Dto
{
    public class OgrenciIdVeDersleriDto
    {
        public int Ogrenciid { get; set; }
        public List<Ders> dersler {get; set;}
    }
}