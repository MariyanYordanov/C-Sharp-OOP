namespace WildFarm.Models.Animals
{
    using Contracts;
    using Food;
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string Sound => "Meow";

        public override void Eat(IFood food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.30;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
        }

    }
}
