using HelpfulNeighbor.web.Features.Centers;

namespace HelpfulNeighbor.web.Features.Map
{
    public class Map
    {
        public int Id { get; set; }
        public int SheltherId { get; set; }
        public int SoupKitchenId { get; set; }
        public int DonationCenterId { get; set; }
        public int MentalHealthTreatmentCenterId { get; set; }
        public int SubtanceAbuseTreatmentCenterId { get; set; }
        public int MailCenterId { get; set; }
        public int EducationCenterId { get; set; }
        public double Distance { get; set; }
    }
}
