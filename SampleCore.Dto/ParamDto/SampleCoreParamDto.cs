using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleCore.Dto.ParamDto
{
    public class SampleCoreParamDto
    {
        [Required]
        [DisplayName("SampleFieldName")]
        public string SampleFieldName { get; set; }
    }
}
