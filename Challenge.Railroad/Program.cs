using Autofac;
using Challenge.Railroad.Abstractions;
using System;
using System.Reflection;

namespace Challenge.Railroad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Injects the all interfaces (with Autofac)
            var programAssembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(programAssembly).AsImplementedInterfaces();

            using (var container = builder.Build())
            {
                var commandSender = container.Resolve<ICommandSender>();

                const string commandInput = "A-B:5, B-C:4, QUERY(A-B), C-D:1, D-C:8, D-E:6, QUERY(C-D), A-D:5, C-D:8, QUERY(C-D), C-E:2, E-B:3, QUERY(A-C), A-E:7";

                Console.WriteLine(commandInput);

                Console.WriteLine("-----");

                commandSender.Execute(commandInput);

                Console.ReadKey();
            }
        }
    }
}
