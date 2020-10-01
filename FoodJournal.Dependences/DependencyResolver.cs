using FoodJournal.BLL;
using FoodJournal.BLL.Interfaces;
using FoodJournal.DAL;
using FoodJournal.DAL.Interfaces;

namespace FoodJournal.Dependences
{
    public static class DependencyResolver
    {
        public static IAccountBLL AccountBLL { get; private set; }
        public static IAccountDAL AccountDal { get; private set; }
        public static IProductBLL ProductBLL { get; private set; }
        public static IProductDAL ProductDAL { get; private set; }
        public static IProfileBLL ProfileBLL { get; private set; }
        public static IProfileDAL ProfileDAL { get; private set; }

        static DependencyResolver()
        {
            AccountDal = new AccountDAL();
            AccountBLL = new AccountBLL(AccountDal);
            ProductDAL = new ProductDAL();
            ProductBLL = new ProductBLL(ProductDAL);
            ProfileDAL = new ProfileDAL();
            ProfileBLL = new ProfileBLL(ProfileDAL);
        }
    }
}