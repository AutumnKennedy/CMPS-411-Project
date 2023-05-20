namespace HelpfulNeighbor.web.Features.Centers
{
    public class SoupKitchenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SoupKitchenGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SoupKitchenCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SoupKitchenUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SoupKitchenListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SoupKitchenOptionDto
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
