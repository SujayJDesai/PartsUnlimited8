using PartsUnlimited.Utils;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PartsUnlimited.Models;
using PartsUnlimited.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace PartsUnlimited.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersQuery _ordersQuery;
        private readonly ITelemetryProvider _telemetry;
		private readonly IShippingTaxCalculator _shippingTaxCalc;
        private readonly UserManager<ApplicationUser> _userManager;

		public OrdersController(IOrdersQuery ordersQuery, ITelemetryProvider telemetryProvider,
			IShippingTaxCalculator shippingTaxCalc, UserManager<ApplicationUser> userManager)
        {
            _ordersQuery = ordersQuery;
            _telemetry = telemetryProvider;
			_shippingTaxCalc = shippingTaxCalc;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(DateTime? start, DateTime? end, string invalidOrderSearch)
        {
            var userId = _userManager.GetUserId(User);

            return View(await _ordersQuery.IndexHelperAsync(userId, start, end, invalidOrderSearch, false));
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                _telemetry.TrackTrace("Order/Server/NullId");
                return RedirectToAction("Index", new { invalidOrderSearch = Request.Query["id"].ToString() });
            }

            var order = await _ordersQuery.FindOrderAsync(id.Value);
            var userId = _userManager.GetUserId(User);

            // If the username isn't the same as the logged in user, return as if the order does not exist
            if (order == null || !String.Equals(order.Username, userId, StringComparison.Ordinal))
            {
                _telemetry.TrackTrace("Order/Server/UsernameMismatch");
                return RedirectToAction("Index", new { invalidOrderSearch = id.ToString() });
            }

            // Capture order review event for analysis
            var eventProperties = new Dictionary<string, string>()
                {
                    {"Id", id.ToString() },
                    {"Username", userId }
                };
            var costSummary = new OrderCostSummary()
            {
                CartSubTotal = 0.ToString("C"),
                CartShipping = 0.ToString("C"),
                CartTax = 0.ToString("C"),
                CartTotal = 0.ToString("C"),
            };
            if (order.OrderDetails == null)
            {
                _telemetry.TrackEvent("Order/Server/NullDetails", eventProperties, null);
            }
            else
            {
                var eventMeasurements = new Dictionary<string, double>()
                {
                    {"LineItemCount", order.OrderDetails.Count }
                };
                _telemetry.TrackEvent("Order/Server/Details", eventProperties, eventMeasurements);

				costSummary = _shippingTaxCalc.CalculateCost(order.OrderDetails, order.PostalCode);
				//var itemsCount = order.OrderDetails.Sum(x => x.Count);
				//var subTotal = order.OrderDetails.Sum(x => x.Count * x.Product.Price);
				//var shipping = itemsCount * (decimal)6.00;
				//var tax = (subTotal + shipping) * (decimal)0.06;
				//var total = subTotal + shipping + tax;

				//costSummary.CartSubTotal = subTotal.ToString("C");
				//costSummary.CartShipping = shipping.ToString("C");
				//costSummary.CartTax = tax.ToString("C");
				//costSummary.CartTotal = total.ToString("C");
			}

            var viewModel = new OrderDetailsViewModel
            {
                OrderCostSummary = costSummary,
                Order = order
            };

            return View(viewModel);
        }
    }
}