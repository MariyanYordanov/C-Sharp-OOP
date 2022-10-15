namespace WildFarm.Factories
{
    using Contracts;
    using Models.Food;
    public static class FoodFactory
    {
        public static IFood CreateFood(string[] foodInfo)
        {
            IFood food = null;


            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
