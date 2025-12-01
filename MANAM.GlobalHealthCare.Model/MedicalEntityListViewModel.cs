using MANAM.GlobalHealthCare.Common.Models;

namespace MANAM.GlobalHealthCare.Model
{
    public class MedicalEntityListViewModel
    {
        public string Category { get; set; } = string.Empty;

        public PagedResult<MedicalEntityItemViewModel> Paged { get; set; } = new PagedResult<MedicalEntityItemViewModel>();
    }

    public class MedicalEntityItemViewModel
    {
        public int Id { get; set; }

        public string AvatarUrl { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? IntroForHomePage { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;
    }
}
