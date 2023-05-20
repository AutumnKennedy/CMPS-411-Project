namespace HelpfulNeighbor.web.Features.Centers
{
    public class DonationCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class DonationCenterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class DonationCenterCreateDto
    {
        public string Name { get; set; }
        public string Location { set; get; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class DonationCenterUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class DonationCenterListDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class DonationCenterOptionDto
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}

