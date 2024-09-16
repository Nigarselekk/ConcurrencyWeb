using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Concurrency.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> List() {

            return View(await _context.Products.ToListAsync());

        }


        // GET: /<controller>/
        public async  Task<IActionResult> Update(int id)
        {
            var product  = await _context.Products.FindAsync(id);

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Product product) {

            try {

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(List));

            } catch(DbUpdateConcurrencyException exception) {

                var exceptionEntry = exception.Entries.First();

                var currentProduct = exceptionEntry.Entity as Product;

                var databasesValues = exceptionEntry.GetDatabaseValues();

                var clientValues = exceptionEntry.CurrentValues;


                if (databasesValues == null)
                {
                    ModelState.AddModelError(string.Empty, "This product has already been deleted..");
            }
                else {
                    var databaseProduct = databasesValues.ToObject() as Product;
                    ModelState.AddModelError(string.Empty, "This product has been updated");
                    ModelState.AddModelError(string.Empty, $"Updated Value: Name: {databaseProduct.Name}, Price:" +
                        $" {databaseProduct.Price}  Stock : {databaseProduct.Stock}");
                }

                return View(product);

            }

        }
 
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

 
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }


}

