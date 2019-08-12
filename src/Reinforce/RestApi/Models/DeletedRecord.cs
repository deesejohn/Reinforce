using System;

namespace Reinforce.RestApi.Models
{
    public class DeletedRecord
    {
        public string Id { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}