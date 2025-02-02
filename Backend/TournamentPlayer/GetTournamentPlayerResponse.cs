namespace VTESTournamentBackend.TournamentPlayer
{
    public class GetTournamentPlayerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Deck { get; set; }
        public string City { get; set; }
        public string Vekn { get; set; }
        public Data.Player Player { get; set; }
    }
}
