using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> formulas;

        public FormulaOneCarRepository()
        {
            formulas = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
            => formulas;

        public void Add(IFormulaOneCar model)
            => formulas.Add(model);

        public IFormulaOneCar FindByName(string name)
            => formulas.FirstOrDefault(f => f.Model == name);

        public bool Remove(IFormulaOneCar model)
            => formulas.Remove(model);
    }
}
