namespace HelpfulNeighbor.web.Features.Centers
{
    public class MentalHealthTreatmentCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MentalHealthTreatmentCenterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MentalHealthTreatmentCenterCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MentalHealthTreatmentCenterUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MentalHealthTreatmentCenterListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class MentalHealthTreatmentCenterOptionDto
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
