using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;

namespace Reinforce.RestApi
{
    public interface IComposite
    {
        [Post("/services/data/{version}/composite")]
        [Header("Authorization", "Bearer")]
        Task<TSObject> PostAsync<TSObject>(
            [Body] CompositeRequest sObject,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );

    }
}
