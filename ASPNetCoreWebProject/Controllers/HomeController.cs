using System.Diagnostics;
using System.Text.Json;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreWebProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ASPNetCoreWebProject.Entities;

namespace ASPNetCoreWebProject.Controllers;

[Authorize(Roles = "Customer,Shipper")]
public class HomeController : Controller
{
    private readonly TmdtContext _context;

    public HomeController(TmdtContext context)
    {
        _context = context;
    }

    public IActionResult Index(string type)
    {
        var products = _context.Products.ToList();

        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "TMDT.products.json");
        var jsonContent = System.IO.File.ReadAllText(jsonPath);

        var jsonDoc = JsonDocument.Parse(jsonContent);
        var productList = new List<ProductViewModel>();

        foreach (var category in jsonDoc.RootElement.EnumerateArray())
        {
            var currentType = category.GetProperty("TYPE").GetString();

            if (!string.IsNullOrEmpty(type) && !currentType.Equals(type, StringComparison.OrdinalIgnoreCase))
                continue;

            var data = category.GetProperty("DATA");

            foreach (var item in data.EnumerateArray())
            {
                var id = item.GetProperty("PRODUCT_ID").GetString();
                var name = item.GetProperty("PRODUCT_NAME").GetString();
                var image = item.GetProperty("IMAGE_URL").GetString();

                var product = products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    productList.Add(new ProductViewModel
                    {
                        ProductId = id,
                        ProductName = item.GetProperty("PRODUCT_NAME").GetString(),
                        ProductType = currentType,
                        ImageUrl = image
                    });
                }
            }
        }

        return View(productList);
    }

    public IActionResult ProductDetails(string id)
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "TMDT.products.json");
        var jsonContent = System.IO.File.ReadAllText(jsonPath);
        var jsonDoc = JsonDocument.Parse(jsonContent);

        var productsFromDb = _context.Products.ToList();

        foreach (var category in jsonDoc.RootElement.EnumerateArray())
        {
            var type = category.GetProperty("TYPE").GetString();
            var data = category.GetProperty("DATA");

            foreach (var item in data.EnumerateArray())
            {
                var productId = item.GetProperty("PRODUCT_ID").GetString();
                if (productId == id)
                {
                    var productInDb = productsFromDb.FirstOrDefault(p => p.ProductId == productId);

                    if (productInDb != null)
                    {
                        var viewModel = new ProductViewModel
                        {
                            ProductId = productId,
                            ProductName = productInDb.ProductName,
                            ProductType = type,
                            ImageUrl = item.GetProperty("IMAGE_URL").GetString(),
                            Color = item.GetProperty("COLOR").GetString(),
                            Origin = item.GetProperty("ORIGIN").GetString(),
                            OtherInformation = item.GetProperty("OTHER_INFORMATION").GetString()
                        };

                        return View(viewModel);
                    }
                }
            }
        }

        return NotFound();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
