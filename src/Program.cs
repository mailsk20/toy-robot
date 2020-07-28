using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using ToyRobot.Interfaces;
using ToyRobot.Logic;

namespace ToyRobot
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        private static readonly string directoryPath = Directory.GetCurrentDirectory() + @"\testdata\";

        public static void Main(string[] args)
        {
            RegisterServices();
            var inputFiles = args.Where(x => File.Exists(directoryPath + x));
            foreach (var path in inputFiles)
            {
                Console.WriteLine("Executing commands from: " + path);
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

                ExecuteCommands(path);

                Console.WriteLine();
                Console.WriteLine("*******************************************************");
                Console.WriteLine();
            }
            Console.ReadLine();
            DisposeServices();
        }

        private static void ExecuteCommands(string path)
        {
            var simulator = _serviceProvider.GetService<ISimulator>();
            using (var file = new StreamReader(directoryPath + path))
            {
                string command;
                while ((command = file.ReadLine()) != null)
                {
                    if (command.Contains("Output")) continue;

                    Console.WriteLine("Executing command: " + command);
                    simulator.Execute(command);
                }
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ISimulator, Simulator>();
            collection.AddScoped<IRobot, Robot>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
