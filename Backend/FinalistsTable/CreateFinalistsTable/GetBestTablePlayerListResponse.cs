namespace VTESTournamentBackend.TablePlayer.GetBestTablePlayers
{
    public class GetBestTablePlayerListResponse
    {
        public int Id { get; set; }
        public int VP { get; set; }
        public int GW { get; set; }
        public int Seat { get; set; }
        public int TableNumber { get; set; }
        public int PlayerId { get; set; }
        public int TableId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Data.Table Table { get; set; }
    }
}
