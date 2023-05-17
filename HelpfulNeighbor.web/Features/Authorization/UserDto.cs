namespace HelpfulNeighbor.web.Features.Authorization
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
