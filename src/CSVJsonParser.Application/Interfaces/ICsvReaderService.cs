using System.IO;

namespace CSVJsonParser.Application.Interfaces
{
    public interface ICsvReaderService
    {
        string[] ReadLines(FileInfo csvFileInfo);
    }
}
