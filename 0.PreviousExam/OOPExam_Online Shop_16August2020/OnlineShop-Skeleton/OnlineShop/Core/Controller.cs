using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComputer> Computers => this.computers.AsReadOnly();

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component;
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            if (componentType == ComponentType.Motherboard.ToString())
            {
                component =
                    new Motherboard(
                        id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component =
                    new PowerSupply(
                        id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = 
                    new RandomAccessMemory(
                        id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = 
                    new SolidStateDrive(
                        id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = 
                    new VideoCard(
                        id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(
                    id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.InvalidComponentType));
            }

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            computer.AddComponent(component);

            components.Add(component);

            return string.Format(SuccessMessages.AddedComponent,
                componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            
            IComputer computer;

            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.InvalidComputerType));
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.ExistingComputerId));
            }


            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NotExistingComputerId));
            }

            if (this.Peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingPeripheralId));
            }

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computer.AddPeripheral(peripheral);

            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral,
                peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault(x =>x.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException(
                   string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer =
                this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NotExistingComputerId));
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer =
                this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = 
                computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }

            IComponent component;

            if (computer.Components.Any(x => x.GetType().Name == componentType))
            {
                component = this.Components.First(x => x.GetType().Name == componentType);
                computer.RemoveComponent(componentType);
                return $"Successfully removed {componentType} with id {component.Id}.";
            }

            return $"Component {componentType} does not exist in Laptop with Id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral component = null;
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (computer.Peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                component = this.Peripherals.First(x => x.GetType().Name == peripheralType);
                computer.RemovePeripheral(peripheralType);
                return $"Successfully removed {peripheralType} with id {component.Id}.";
            }

            return $"Peripheral {peripheralType} does not exist in Laptop with Id {computer.Id}.";
        }
    }
}
