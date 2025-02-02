namespace VTESTournamentBackend.Data
{
    public class TablePlayer
    {
        public int Id { get; set; }
        public int VP { get; set; }
        public int GW { get; set; }
        public int Seat { get; set; }
        public int PlayerId {  get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public Player Player { get; set; }
    }
}
