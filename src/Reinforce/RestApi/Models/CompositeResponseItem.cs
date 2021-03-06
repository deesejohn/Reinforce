﻿using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class CompositeResponseItem<T>
    {
        public T Body { get; set; }
        public IDictionary<string, string> HttpHeaders { get; set; }
        public int? HttpStatusCode { get; set; }
        public string ReferenceId { get; set; }
    }
}
