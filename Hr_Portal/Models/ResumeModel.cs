using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hr_Portal.Models
{
    public class ResumeModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }

        public long ContactNo { get; set; }

        public DateTime? Dates { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Qualification { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string SkillSet { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Experience { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Reference { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string? Status { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comments { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ResumeName { get; set; }

        [NotMapped]
        public IFormFile? ResumeFile { get; set; }
    }

    public class ResumeStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
