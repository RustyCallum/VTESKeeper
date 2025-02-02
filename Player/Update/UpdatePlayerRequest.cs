namespace VTESTournamentBackend.Player.Update
{
    public class UpdatePlayerRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Vekn { get; set; }
        //public DateTime CreatedDateTime { get; set; }
    }
}
