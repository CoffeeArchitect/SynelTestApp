namespace SynelTestApp.BLL.Services
{
    internal class ParsingService : IParsingService
    {
        public List<Employee> ReadFromFile(IFormFile csvFile)
        {
            try
            {
                using (var streamReader = new StreamReader(csvFile.OpenReadStream(), Encoding.Default))
                using (var csvReader = new CsvReader(streamReader, new CultureInfo("en-GB"))) //Used CultureInfo("en-GB") for "dd/MM/yyyy" template
                {
                    csvReader.Context.RegisterClassMap<AppEmployeeMapping>();
                    var employeeRecords = new List<Employee>();

                    csvReader.Read();
                    csvReader.ReadHeader();

                    while (csvReader.Read())
                    {
                        employeeRecords.Add(csvReader.GetRecord<Employee>());
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
