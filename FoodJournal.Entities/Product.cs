
namespace FoodJournal.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Calorific { get; set; }
        public int NetMass { get; set; }
        public byte[] Image { get; set; }
        public Products Category { get; set; }
    }
}

public enum Products
{
    All = 0,
    Fruits = 1,
    DriedFruits = 2,
    Vegetables = 3,
    Mushrooms = 4,
    Grocery = 5,
    Nuts = 6,
    BakeryProducts = 7,
    Sweets = 8,
    MilkProducts = 9,
    FishAndSeafood = 10,
    Meat = 11,
    FastFood = 12
}