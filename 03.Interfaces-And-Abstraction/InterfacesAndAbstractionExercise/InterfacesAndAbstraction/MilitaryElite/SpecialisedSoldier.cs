using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    abstract class SpecialisedSoldier : ISpecialisedSoldier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Corps Corps { get; set; }
    }
}
