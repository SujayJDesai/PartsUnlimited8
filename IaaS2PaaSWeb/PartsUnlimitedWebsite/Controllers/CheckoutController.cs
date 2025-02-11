using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PartsUnlimited.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace PartsUnlimited.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IPartsUnlimitedContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(IPartsUnlimitedContext context, UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        const string PromoCode = "FREE";

        //
        // GET: /Checkout/

        public async Task<ActionResult> AddressAndPayment()
        {
            var id = _userManager.GetUserId(User);
            var user = await db.Users.FirstOrDefaultAsync(o => o.Id == id);

            var order = new Order
            {
                Name = user.Name,
                Email = user.Email,
                Username = user.UserName
            };

            return View(order);
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddressAndPayment(Order order)
        {
            var formCollection = Request.Form;

            try
            {
            if (string.Equals(formCollection["PromoCode"].FirstOrDefault(), PromoCode,
                StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.GetUserName();
                    order.OrderDate = DateTime.Now;

                    //Add the Order
                    db.Orders.Add(order);

                    //Process the order
                    var cart = ShoppingCart.GetCart(db, HttpContext);
                    cart.CreateOrder(order);

                    // Save all changes
                    await db.SaveChangesAsync(CancellationToken.None);

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            var username = User.Identity.GetUserName();

            Order order = db.Orders.First(
                o => o.OrderId == id &&
                o.Username == username);

            if (order != null)
            {
                return View(order);
            }
            else
            {
                return View("Error");
            }
        }
    }
}