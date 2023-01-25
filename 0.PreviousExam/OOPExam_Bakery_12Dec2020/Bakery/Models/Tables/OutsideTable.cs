using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        const decimal InitialPricePerPerson = 3.50m;
        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

    }
}
