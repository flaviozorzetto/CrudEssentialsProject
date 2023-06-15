using CrudEssentialsProject.Services.Enums;

namespace CrudEssentialsProject.Models.Dto
{
    public class ServiceResponse
    {
        public ServiceResponseStatus Status { get; set; }
        public object? Message { get; set; }
    }
}
