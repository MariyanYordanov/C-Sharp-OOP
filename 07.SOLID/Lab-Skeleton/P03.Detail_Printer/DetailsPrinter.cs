namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using P03.Detail_Printer;
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public string Print(IEmployee employee)
        {
            StringBuilder sb = new StringBuilder();
            if (this.employees.Contains(employee))
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
