namespace SynelTestApp.BLL.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
        }
        
    }
}
