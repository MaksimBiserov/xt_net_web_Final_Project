
namespace FoodJournal.PL.WebPages.Models
{
    public static class AuthModel
    {
        public static bool CanLoginAdmin(string login, string password) =>
            login == "admin" && password == "admin";
    }
}