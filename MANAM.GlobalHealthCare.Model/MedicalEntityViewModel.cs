using Microsoft.AspNetCore.Http;

namespace MANAM.GlobalHealthCare.Model
{
    public class MedicalEntityViewModel
    {
        public int Id { get; set; }

        public string AvatarUrl { get; set; } = string.Empty;

        public string Category { get; set; } = null!;

        public string? IntroForHomePage { get; set; } = string.Empty;

        public string? Type { get; set; } = string.Empty;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
