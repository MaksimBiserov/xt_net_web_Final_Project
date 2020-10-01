﻿
namespace FoodJournal.Entities
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double BodyWeight { get; set; }
        public Goals Goal { get; set; }
    }

    public enum Goals
    {
        Stay = 1,
        Thin = 2,
        Fatten = 3
    }
}