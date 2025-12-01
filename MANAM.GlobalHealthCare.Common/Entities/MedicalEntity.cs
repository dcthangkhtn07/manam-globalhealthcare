using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MANAM.GlobalHealthCare.Common.Entities
{
    [Table("MedicalEntities", Schema = "dbo")]
    public class MedicalEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Type { get; set; }

        public string? IntroForHomePage { get; set; }

        public string Category { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string AvatarUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsPublished { get; set; } = false;

        public DateTime? PublishedDate { get; set; }

        public int ViewCount { get; set; } = 0;

        public bool IsDeleted { get; set; } = false;
    }
}
