using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Computer(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance)
           : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
             get
             {
                if (!this.components.Any())
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance 
                    + this.Components.Average(x => x.OverallPerformance);
             }
        }

        public override decimal Price
            => base.Price + Components.Sum(x => x.Price) + Peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (Components.Any(x =>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingComponent,
                    component.GetType().Name, GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = 
                Components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingComponent,
                    componentType, GetType().Name, this.Id));
            }

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral =
                Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.NotExistingPeripheral,
                    peripheralType, GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($" Components ({Components.Count}):");
            foreach (var component in this.Components)
            {
                stringBuilder.AppendLine($"  {component}");
            }

            stringBuilder.AppendLine($" Peripherals ({Peripherals.Count});" +
                $" Average Overall Performance " +
                $"({Peripherals.Average(x => x.OverallPerformance):f2}):");
            foreach (var peripheral in this.Peripherals)
            {
                stringBuilder.AppendLine($"  {peripheral}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
