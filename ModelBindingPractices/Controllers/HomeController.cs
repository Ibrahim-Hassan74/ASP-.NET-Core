using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingPractices.CustomModelBinder;
using ModelBindingPractices.Models;

namespace ModelBindingPractices.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
                return Json(person);
            var errors = string.Join("\n",
                ModelState.Values.SelectMany(err => err.Errors)
                .Select(message => message.ErrorMessage));
            return BadRequest(errors);
        }
        [Route("/order")]
        public IActionResult Order([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = String.Join("\n", 
                     ModelState.Values
                    .SelectMany(values => values.Errors)
                    .Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            var invoice = order.InvoicePrice;
            var product = order.Products.ToList();
            var currentPrice = product.Sum(p => p.Price * p.Quantity);
            if (invoice != currentPrice)
                return BadRequest("incorrect invoice");

            var obj = new { OrderNumber = new Random().Next(1, 100000) };
            order.OrderNo = obj.OrderNumber;
            return Json(obj);
        }
    }
}
