namespace VTESTournamentBackend.Player.GetByID
{
    public class GetPlayerByIdRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Vekn { get; set; } = string.Empty;
    }
}
