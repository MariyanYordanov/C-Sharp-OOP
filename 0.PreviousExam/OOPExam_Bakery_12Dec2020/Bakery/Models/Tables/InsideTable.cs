using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using System.Text;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        const decimal InitialPricePerPerson = 2.50m;

        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

    }
}
