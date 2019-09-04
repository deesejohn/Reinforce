using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ActionsResponse
    {
        public IEnumerable<InvocableAction> Actions { get; set; }
    }
}