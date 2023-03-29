using System.ComponentModel.DataAnnotations;

namespace Hr_Portal.Models
{
    public class JavaQuestion
    {
        [Key]
        public int QnId { get; set; }

        [StringLength(250)]
        public string QnInWords { get; set; } = null!;

        [StringLength(150)]
        public string? ImageName { get; set; }

        [StringLength(50)]
        public string Option1 { get; set; } = null!;

        [StringLength(50)]
        public string Option2 { get; set; } = null!;

        [StringLength(50)]
        public string Option3 { get; set; } = null!;

        [StringLength(50)]
        public string Option4 { get; set; } = null!;

        public int Answer { get; set; }
    }
}
