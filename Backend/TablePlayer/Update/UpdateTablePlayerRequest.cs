namespace VTESTournamentBackend.TablePlayer.Update
{
    public class UpdateTablePlayerRequest
    {
        public int Id { get; set; }
        public int VP { get; set; }
        public int GW { get; set; }
        public int Seat { get; set; }
        public int PlayerId { get; set; }
        public int TableId { get; set; }
        public Data.Table Table { get; set; }
        public Data.Player Player { get; set; }
    }
}
