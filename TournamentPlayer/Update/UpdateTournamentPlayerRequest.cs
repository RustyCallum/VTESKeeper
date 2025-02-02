namespace VTESTournamentBackend.TournamentPlayer.Update
{
    public class UpdateTournamentPlayerRequest
    {
        public int Id { get; set; }
        public byte[] Deck { get; set; }
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
    }
}
