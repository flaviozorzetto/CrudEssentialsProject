using CrudEssentialsProject.Services.Enums;

namespace CrudEssentialsProject.Models.Dto
{
    public class ServiceResponseDto<T>
    {
        public ServiceResponseStatus Status { get; set; }
        public T? Message { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
