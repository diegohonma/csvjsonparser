using CSVJsonParser.Application.Interfaces;
using CSVJsonParser.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CSVJsonParser.Presentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterDependencies();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var handler = serviceProvider.GetService<IHandlerCsvJsonParser>();
            var success = handler.Parse(args[0]);

            Console.WriteLine(
                success ? "CSV files processed successfully" : "A problem occured while processing CSV files."
                );

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();
        }
    }
}
