using Microsoft.AspNetCore.Mvc;

namespace SynelTestApp.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IParsingService _parsingService;
        private readonly IRepository _repository;

        public EmployeeController(IParsingService parsingService, IRepository repository)
        {
            _parsingService = parsingService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        // Import CSV File
        [HttpPost]
        public async Task<IActionResult> ImportCSVAsync(IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                var newEmployeesList = _parsingService.ReadFromFile(file);
                foreach (var employee in newEmployeesList)
                {
                    await _repository.AddEmployee(employee);
                }
            }
            return Redirect("/Employee/Index");
        }

        // Get data from database
        public async Task<IActionResult> GetData([FromBody] DataManagerRequest dataManagerRequest)
        {
            IEnumerable dataSource = await _repository.GetAll();
            var operation = new DataOperations();

            // Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                 dataSource = operation.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Sorting
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                dataSource = operation.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }
            
            // Pagination
            int count = dataSource.Cast<Employee>().Count();
            if (dataManagerRequest.Skip != 0)
            {
                dataSource = operation.PerformSkip(dataSource, dataManagerRequest.Skip);
            }
            if (dataManagerRequest.Take != 0)
            {
                dataSource = operation.PerformTake(dataSource, dataManagerRequest.Take);
            }
            return dataManagerRequest.RequiresCounts ? new JsonResult(new { result = dataSource, count }) : new JsonResult(dataSource);
        }

        // Update
        public async Task<ActionResult> Update([FromBody] Models.CRUDModel<Employee> value)
        {
            var position = value.value;
            await _repository.UpdateEmployee(position);

            return Json(value.value);
        }

        // Delete
        public async Task<ActionResult> Delete([FromBody] Models.CRUDModel<Employee> value)
        {
            await _repository.DeleteEmployeeAsync(value.key);
            return Json(value);
        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
