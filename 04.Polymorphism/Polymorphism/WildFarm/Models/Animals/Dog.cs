namespace WildFarm.Models.Animals
{
    using Contracts;
    using Food;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
             : base(name, weight, livingRegion)
        {
        }

        public override string Sound => "Woof!";

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.40;
        }
        public override string ToString()
        {
            return base.ToString() + $" [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
