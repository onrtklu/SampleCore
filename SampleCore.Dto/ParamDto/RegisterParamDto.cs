using System.ComponentModel.DataAnnotations;

namespace SampleCore.Dto.ParamDto
{
    public class RegisterParamDto
    {
        [Required]
        public string adi { get; set; }
        [Required]
        public string soyadi { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string cinsiyet { get; set; }
        [Required]
        public string sifre { get; set; }
    }
}
