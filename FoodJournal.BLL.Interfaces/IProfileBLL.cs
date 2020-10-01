using FoodJournal.Entities;

namespace FoodJournal.BLL.Interfaces
{
    public interface IProfileBLL
    {
        int Add(Profile profile);
        void DeleteById(int id);
        void Edit(int id, string name, double bodyWeight, Goals goal);
    }
}