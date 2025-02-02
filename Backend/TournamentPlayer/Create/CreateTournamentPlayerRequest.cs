namespace VTESTournamentBackend.TournamentPlayer.Create
{
    public class CreateTournamentPlayerRequest
    {
        public byte[] Deck { get; set; }
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }
    }
}
