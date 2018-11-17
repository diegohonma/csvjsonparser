using CSVJsonParser.Application;
using CSVJsonParser.Application.Interfaces;
using CSVJsonParser.Application.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CSVJsonParser.Ioc
{
    public static class ServiceCollectionEx
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            RegisterHandles(services);
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICsvJsonParserService>(x =>
                new CsvJsonParserService(new Dictionary<Type, ICsvClassParserService>
                {
                    {typeof(BookingsModel), new CsvBookingParserService()}
                }));

            services.AddScoped<ICsvReaderService, CsvReaderService>();
            services.AddScoped<ICreateJsonFileService, CreateJsonFileService>();
        }

        private static void RegisterHandles(IServiceCollection services)
        {
            services.AddScoped<IHandlerCsvJsonParser, HandlerCsvJsonParser>();
        }
    }
}
