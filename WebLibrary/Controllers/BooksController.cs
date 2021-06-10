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
        public IActionResult SearchBooks()
        {
            var list = _context.Books.ToList();
            return Ok(list);
        }

        //[HttpPost]
        //[Route("add")]
        ////[Authorize(Roles = Roles.Admin)]
        //public IActionResult AddBook([FromBody] BookViewModelsError book)
        //{
        //    _context.Books.Add(book);
        //    _context.SaveChanges();
        //    //var dir = Directory.GetCurrentDirectory();
        //    //var dirSave = Path.Combine(dir, "uploads");
        //    //var imageName = Path.GetRandomFileName() + ".jpg";
        //    //var imageSaveFolder = Path.Combine(dirSave, imageName);
        //    //var image = car.Image.LoadBase64();
        //    //image.Save(imageSaveFolder);
        //    return Ok(new { message="Додано" });
        //}

    }
}
