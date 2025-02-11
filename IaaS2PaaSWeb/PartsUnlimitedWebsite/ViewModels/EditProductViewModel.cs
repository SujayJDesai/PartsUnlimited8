using System.Collections.Generic;
using PartsUnlimited.Models;
using Microsoft.AspNetCore.Mvc;


namespace PartsUnlimited.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}