namespace HelpfulNeighbor.web.Features.Centers
{
    public class MailCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MailCenterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MailCenterCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MailCenterUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MailCenterListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MailCenterOptionDto
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
