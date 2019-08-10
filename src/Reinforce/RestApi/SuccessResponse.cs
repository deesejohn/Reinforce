using System.Collections.Generic;

namespace Reinforce.RestApi
{
    public class SuccessResponse
    {
        public string Id { get; set; }
        public IEnumerable<ErrorResponse> Errors { get; set; }
        public bool? Success { get; set; }
    }
}