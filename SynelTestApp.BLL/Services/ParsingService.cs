namespace SynelTestApp.BLL.Services
{
    public class ParsingService : IParsingService
    {
        public List<Employee> ReadFromFile(IFormFile file)
        {
            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream(), Encoding.Default))
                using (var fileReader = new CsvReader(streamReader, new CultureInfo("en-GB")))
                {
                    fileReader.Context.RegisterClassMap<AppEmployeeMapping>();
                    var employeeRecords = new List<Employee>();

                    fileReader.Read();
                    fileReader.ReadHeader();

                    while (fileReader.Read())
                    {
                        employeeRecords.Add(fileReader.GetRecord<Employee>());
                    }
                    return employeeRecords;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<byte[]> WriteCSVFileAsync(IEnumerable<Employee> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, new CultureInfo("en-GB"));

                csvWriter.Context.RegisterClassMap<AppEmployeeMapping>();
                await csvWriter.WriteRecordsAsync(records);
            }

            return memoryStream.ToArray();
        }
    }
}
