using System.ComponentModel.DataAnnotations;

namespace SampleCore.Core.Entities
{
    public class Person
    {
        [Key]
        public int uye_id { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string email { get; set; }
        public string cinsiyet { get; set; }
        public bool aktif { get; set; }
        public System.DateTime dogum_tarihi { get; set; }
        public System.DateTime eklenme_tarih { get; set; }
        public System.DateTime guncelleme_tarih { get; set; }
        public string sifre { get; set; }
    }
}
