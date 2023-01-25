namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        const int InitialBreadPortion = 200;

        public Bread(string name, decimal price)
            : base(name, InitialBreadPortion, price)
        {
        }
    }
}
