namespace SampleCore.Core.Entities.Log
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class TempRequestLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string RequestUrl { get; set; }
        public string IpAddress { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}