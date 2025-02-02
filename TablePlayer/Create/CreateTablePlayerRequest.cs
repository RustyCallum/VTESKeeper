namespace VTESTournamentBackend.TablePlayer.Create
{
    public class CreateTablePlayerRequest
    {
        public int VP { get; set; }
        public int GW { get; set; }
        public int Seat { get; set; }
        public int TournamentPlayerId { get; set; }
        public int TableId { get; set; }
    }
}
