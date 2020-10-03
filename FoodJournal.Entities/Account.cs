
namespace FoodJournal.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
        public double BodyWeight { get; set; }
        public Goals Goal { get; set; }
    }
}

public enum Goals
{
    Stay = 1,
    Thin = 2,
    Fatten = 3
}