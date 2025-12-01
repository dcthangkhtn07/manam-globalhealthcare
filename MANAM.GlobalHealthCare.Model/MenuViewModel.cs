namespace MANAM.GlobalHealthCare.Model
{
    public class MenuViewModel
    {
        public List<MenuItemViewModel> MedicalServices { get; set; } = new List<MenuItemViewModel>();
    }

    public class MenuItemViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string? Type  { get; set; } = string.Empty;

        public string? Category { get; set; } = string.Empty;    
    }
}
