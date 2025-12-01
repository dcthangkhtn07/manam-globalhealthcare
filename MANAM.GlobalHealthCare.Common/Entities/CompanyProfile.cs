namespace MANAM.GlobalHealthCare.Common.Entities
{
    public class CompanyProfile
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string? HeadquarterAddress { get; set; }

        public string? Hotline1 { get; set; }

        public string? Hotline2 { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? FacebookAddress { get; set; }

        public string? ZaloAddress { get; set; }
        
        public string? YoutubeAddress { get; set; }

        public string? MessengerAddress { get; set; }
    }
}
