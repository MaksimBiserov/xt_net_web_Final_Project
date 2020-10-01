using FoodJournal.Entities;

namespace FoodJournal.DAL.Interfaces
{
    public interface IProfileDAL
    {
        int Add(Profile profile);
        void DeleteById(int id);
        void Edit(int id, string name, double bodyWeight, Goals goal);
    }
}