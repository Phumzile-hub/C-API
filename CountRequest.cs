using System.Collections.Generic;

namespace GenericListAPI.Models
{
    public class CountRequest
    {
        public List<object> Items { get; set; }
        public object Item { get; set; }
    }
}