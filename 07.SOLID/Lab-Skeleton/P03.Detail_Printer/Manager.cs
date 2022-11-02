using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public string Name { get; }
        public IReadOnlyCollection<string> Documents { get; }

        public override string ToString()
        {
            return $"{this.Name} {string.Join(" ", this.Documents)}";
        }

    }
}
