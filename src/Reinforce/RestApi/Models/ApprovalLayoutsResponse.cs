using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ApprovalLayoutsResponse
    {
        public IEnumerable<ApprovalLayout> ApprovalLayouts { get; set; }
    }
}