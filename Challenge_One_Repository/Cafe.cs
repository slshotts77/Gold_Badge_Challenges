using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repository
{
    public enum SideItem
    {
        Salad = 1,     // = 1 changes the index from 0 to start at 1
        Rolls,
        Fries,
        Coleslaw,
        MashedPotatoes,
        BakedPotatoes,
        Vegetables        
    }

    // Plan Old C# Object (POCO)
    public class MealItems
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double MealNumber { get; set; }
        public bool IsAllergyFriendly { get; set; }
        public SideItem ItemOnSide { get; set; }

        public MealItems() { }

        public MealItems(string name, string description, string ingredients, double number, bool isAllergyFriendly, SideItem itemOnSide)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            MealNumber = number;
            IsAllergyFriendly = isAllergyFriendly;
            ItemOnSide = itemOnSide;
        }
    }
}
