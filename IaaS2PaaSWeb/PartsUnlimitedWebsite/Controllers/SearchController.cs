using System.Threading.Tasks;
using PartsUnlimited.ProductSearch;
using Microsoft.AspNetCore.Mvc;


namespace PartsUnlimited.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductSearch search;

        public SearchController(IProductSearch search)
        {
            this.search = search;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string q)
        {
            var result = await search.Search(q);

            return View(result);
        }
    }
}
