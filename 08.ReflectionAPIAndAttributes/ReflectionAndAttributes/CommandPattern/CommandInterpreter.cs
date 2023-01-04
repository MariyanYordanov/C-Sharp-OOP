using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();
            string commandName = input[0];
            string[] value = input.Skip(1).ToArray();

            Type classType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command");

            if (classType == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            Type commandInterface = classType.GetInterface("ICommand");

            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            ICommand comand = Activator.CreateInstance(classType) as ICommand;

            string result = comand.Execute(value);

            return result;
        }
    }
}
