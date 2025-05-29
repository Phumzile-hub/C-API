using Microsoft.AspNetCore.Mvc;
using GenericListAPI.Helpers;
using GenericListAPI.Models;
using System.Linq;
using System;

namespace GenericListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        [HttpPost("count")]
        public IActionResult CountItemOccurrences([FromBody] CountRequest request)
        {
            if (request?.Items == null || request.Item == null)
                return BadRequest("Invalid input");

            var type = request.Items.First().GetType();
            var method = typeof(ListUtils).GetMethod("CountOccurrences")?.MakeGenericMethod(type);

            var convertedList = ConvertList(request.Items, type);
            var convertedItem = Convert.ChangeType(request.Item, type);

            var result = method?.Invoke(null, new object[] { convertedList, convertedItem });

            return Ok(new { count = result });
        }

        private dynamic ConvertList(List<object> input, Type type)
        {
            var castMethod = typeof(Enumerable).GetMethod("Cast")?.MakeGenericMethod(type);
            var toListMethod = typeof(Enumerable).GetMethod("ToList")?.MakeGenericMethod(type);
            var casted = castMethod?.Invoke(null, new object[] { input });
            return toListMethod?.Invoke(null, new object[] { casted });
        }
    }
}