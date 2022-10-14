using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IEngineer : IRepair, ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; set; }
    }
}
