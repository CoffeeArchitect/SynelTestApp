
namespace SynelTestApp.BLL.Services
{
    public interface IParsingService
    {
        List<Employee> ReadFromFile(IFormFile csvFile);
        Task<byte[]> WriteCSVFileAsync(IEnumerable<Employee> employees);
    }
}
