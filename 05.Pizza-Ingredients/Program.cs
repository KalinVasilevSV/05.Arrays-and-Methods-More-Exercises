using System;
using System.Collections.Generic;

namespace _05.Pizza_Ingredients
{
    //Really happy with class use in this one

    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();
            int ingredientLength = int.Parse(Console.ReadLine());

            Pizza pizza = new Pizza();

            pizza.AddValidIngredients(ingredients, ingredientLength);

            Pizza.Present(pizza);

        }

        private class Pizza
        {
            public List<string> Ingredients = new List<string>();

            public string ListOfIncludedIngredients
            {
                get
                {
                    string ingredients=null;

                    for (int i = 0; i < Ingredients.Count; i++)
                    {
                        ingredients += " " + Ingredients[i];
                            if (i != Ingredients.Count - 1) ingredients += ",";
                    }

                    return ingredients;
                }
            }

            public int NumberOfIngredients
            {
                get
                {
                    return Ingredients.Count;
                }
            }

            public void AddValidIngredients(string[] ingredientArr, int ingredientLength)
            {
                foreach (string ingredient in ingredientArr)
                {
                    if (ingredient.Length == ingredientLength)
                    {
                        Ingredients.Add(ingredient);
                        Console.WriteLine($"Adding {ingredient}.");

                        if (Ingredients.Count == 10) break;
                    }
                }
            }

            public static void Present(Pizza pizza)
            {
                Console.WriteLine($"Made pizza with total of {pizza.NumberOfIngredients} ingredients.");
                Console.WriteLine($"The ingredients are:{pizza.ListOfIncludedIngredients}.");
            }
        }
    }
}
