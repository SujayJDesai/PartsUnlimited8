using System;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using PartsUnlimited.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PartsUnlimited.Utils
{
    public class LayoutDataAttribute : ActionFilterAttribute
    {
        private readonly IPartsUnlimitedContext _dataContext;
        private readonly IMemoryCache _memoryCache;

        public LayoutDataAttribute(IPartsUnlimitedContext dataContext, IMemoryCache memoryCache)
        {
            _dataContext = dataContext;
            _memoryCache = memoryCache;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var cart = ShoppingCart.GetCart(_dataContext, filterContext.HttpContext);
            var summary = cart.GetCartItems()
                .Select(a => a.Product.Title)
                .OrderBy(x => x)
                .ToList();

            if (!_memoryCache.TryGetValue("latestProduct", out Product latestProduct))
            {
                latestProduct = _dataContext.Products.OrderByDescending(a => a.Created).FirstOrDefault();
                if (latestProduct != null)
                {
                    _memoryCache.Set("latestProduct", latestProduct, TimeSpan.FromMinutes(10));
                }
            }

            if (filterContext.Controller is Controller controller)
            {
                controller.ViewBag.Categories = _dataContext.Categories.ToList();
                controller.ViewBag.CartSummary = summary;
                controller.ViewBag.Product = latestProduct;
            }
        }
    }
}