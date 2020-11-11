using System.Threading.Tasks;
using BaseTemplate.Models;
using Refit;

namespace BaseTemplate.Services
{
    public interface IAndalusiaApi
    {
        [Get("/odata/ClinicTagOData")]
        Task<Root> GetUsers([Header("Authentication")] string Authentication, [Query("", "$")] QueryString query);
        [Headers("Content-Type: application/json")]
        [Post("/api/ClinicTag/AddClinicTag")]
        Task<int> SendUser([Header("Authentication")] string Authentication, [Body] Value obj);
        [Headers("Content-Type: application/json")]
        [Post("/api/Syncronization/SyncTimelineData")]
        Task<MedicalHistoryResponse> FetchMedicalHistory([Header("Authentication")] string Authentication, [Body] MedicalHistoryRequest obj);
    }
}
