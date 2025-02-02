namespace VTESTournamentBackend.Data
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        public byte[] Deck { get; set; }
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public Player Player { get; set; }
    }
}
