using FoodJournal.Entities;
using FoodJournal.BLL.Interfaces;
using FoodJournal.DAL.Interfaces;

namespace FoodJournal.BLL
{
    public class ProfileBLL : IProfileBLL
    {
        private readonly IProfileDAL profileDAL;

        public ProfileBLL(IProfileDAL profileDAL)
        {
            this.profileDAL = profileDAL;
        }

        public int Add(Profile profile)
        {
            return profileDAL.Add(profile);
        }

        public void DeleteById(int id)
        {
            profileDAL.DeleteById(id);
        }

        public void Edit(int id, string name, double bodyWeight, Goals goal)
        {
            profileDAL.Edit(id, name, bodyWeight, goal);
        }
    }
}