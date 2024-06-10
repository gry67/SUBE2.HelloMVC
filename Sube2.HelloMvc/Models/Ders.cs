namespace Sube2.HelloMvc.Models
{
    public class Ders
    {
        public int DersId { get; set; }
        public string DersAd { get; set; }
        public int Kredi { get; set; }
        public ICollection<OgrenciDers> Ogrenciler { get; set; } 
    }
}
