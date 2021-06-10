using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Constants;
using WebLibrary.EFContext;
using WebLibrary.EFContext.Data;
using WebLibrary.Models;

namespace WebGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("search")]
        public async Task <IActionResult> SearchBooks()
        {
            return await Task.Run(() =>
            {
                return Ok(_context.Books.AsQueryable());
            });
           
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            return await Task.Run(() =>
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return Ok(new { message = "Додано" });
            });
            
           
           
            //var dir = Directory.GetCurrentDirectory();
            //var dirSave = Path.Combine(dir, "uploads");
            //var imageName = Path.GetRandomFileName() + ".jpg";
            //var imageSaveFolder = Path.Combine(dirSave, imageName);
            //var image = car.Image.LoadBase64();
            //image.Save(imageSaveFolder);
          
        }


        [HttpPut("{id}")]
        //[Route("update")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            return await Task.Run(() => {
                
                var books = _context.Books.FirstOrDefault(x => x.Id == id);
               
                if (books != null)
                {
                    //  Редагування
                    books.Name = book.Name;
                    books.Author = book.Author;
                    books.Description = book.Description;
                    books.Year = book.Year;
                   
                    _context.SaveChanges();
                }

                return Ok(new { message = "Дані оновлено!" });
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            return await Task.Run(() =>
            {

            
            var books = _context.Books.SingleOrDefault(x => x.Id == id);
            if (books != null)
            {
                    _context.Remove(books);
                    _context.SaveChanges();
                }

            return Ok("Книга видалена");
            });
        }
    }
}
