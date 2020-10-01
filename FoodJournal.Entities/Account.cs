
namespace FoodJournal.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
        public int ProfileID { get; set; }
    }
}