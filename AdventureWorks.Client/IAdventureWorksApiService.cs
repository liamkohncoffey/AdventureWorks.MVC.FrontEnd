using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Domain.Response;
using RestEase;

namespace AdventureWorks.Client
{
    public interface IAdventureWorksApiService
    {
        [Get("Person")]
        Task<PersonResponse> GetUserAccount([Query] Guid rowGuid, [Header("Authorization")] string authorization, CancellationToken cancellationToken);
    }
}