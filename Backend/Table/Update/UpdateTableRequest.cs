namespace VTESTournamentBackend.Table.Update
{
    public class UpdateTableRequest
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int Round { get; set; }
        public int TableNumber { get; set; }
    }
}
