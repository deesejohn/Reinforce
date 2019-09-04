using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class InvokedActionResponse<T>
    {
        public string ActionName { get; set; }
        public IEnumerable<ErrorResponse> Errors { get; set; }
        public bool? IsSuccess { get; set; }
        public IEnumerable<T> OutputValues { get; set; }
    }
}