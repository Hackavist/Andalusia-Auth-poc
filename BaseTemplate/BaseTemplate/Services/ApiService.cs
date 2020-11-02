using System.Threading.Tasks;
using BaseTemplate.Models;
using Refit;

namespace BaseTemplate.Services
{
    public interface IAndalusiaApi
    {
        [Get("/odata/ClinicTagOData?&$count=true&%24format=json&%24top=10&%24orderby=ArName")]
        Task<Root> GetUsers([Header("Authentication")] string Authentication);
    }
}
