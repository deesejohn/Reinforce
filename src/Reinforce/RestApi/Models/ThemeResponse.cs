using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ThemeResponse
    {
        public IEnumerable<ThemeItem> ThemeItems { get; set; }
    }
}