using System.ComponentModel.DataAnnotations;

namespace SampleCore.Dto.ParamDto
{
    public class LoginParamDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
