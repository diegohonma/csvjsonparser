using CSVJsonParser.Application.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace CSVJsonParser.Application
{
    public class HandlerCsvJsonParser : IHandlerCsvJsonParser
    {
        private readonly ICsvReaderService _csvReaderService;
        private readonly ICsvJsonParserService _csvJsonParserService;
        private readonly ICreateJsonFileService _createJsonFileService;

        public HandlerCsvJsonParser(ICsvReaderService csvReaderService,
            ICsvJsonParserService csvJsonParserService,
            ICreateJsonFileService createJsonFileService)
        {
            _csvReaderService = csvReaderService;
            _csvJsonParserService = csvJsonParserService;
            _createJsonFileService = createJsonFileService;
        }

        public bool Parse(string csvDirectory)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(csvDirectory);

                var csvLines = directoryInfo
                    .GetFiles()
                    .Aggregate(new string[0], (current, file) => current.Concat(_csvReaderService.ReadLines(file)).ToArray());
                
                _createJsonFileService
                    .CreateJsonFile(
                        directoryInfo.FullName,
                        _csvJsonParserService.Parse(csvLines));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
