using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; set; }

        void CompleteMission(string codeName);
    }
}
