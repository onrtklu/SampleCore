using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleCore.Core.Entities
{
    [Table("SampleCoreEntity", Schema = "dbo")]
    public class SampleCoreEntity
    {
        [Key]
        public int id { get; set; }
        public string adi { get; set; }
        public int sira_no { get; set; }
        public bool aktif { get; set; }
    }
}
