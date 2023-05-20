namespace HelpfulNeighbor.web.Features.Centers
{
    public class SubstanceAbuseTreatmentCenterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SubstanceAbuseTreatmentCenterGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SubstanceAbuseTreatmentCenterCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SubstanceAbuseTreatmentCenterUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SubstanceAbuseTreatmentCenterListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string HoursOfOperation { get; set; }
        public int TypeId { get; set; }
    }

    public class SubstanceAbuseTreatmentCenterOptionDto
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
