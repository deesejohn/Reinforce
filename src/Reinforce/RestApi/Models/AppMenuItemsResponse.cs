using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class AppMenuItemsResponse
    {
        public IEnumerable<AppMenuItem> AppMenuItems { get; set; }
    }
}