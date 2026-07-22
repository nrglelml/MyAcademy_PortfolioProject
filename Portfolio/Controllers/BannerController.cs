using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Entities;
using System;
using System.IO;
using System.Linq;

namespace Portfolio.Controllers
{
    public class BannerController : BaseAdminController
    {
        private readonly AppDBContext _context;

        public BannerController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var banner = _context.Banners.FirstOrDefault();
            return View(banner);
        }

        [HttpGet("CreateBanner")]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost("CreateBanner")]
        public IActionResult CreateBanner(Banner banner, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                banner.ImageUrl = SaveImageFile(imageFile);
            }

            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("UpdateBanner/{id}")]
        public IActionResult UpdateBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        [HttpPost("UpdateBanner")]
        public IActionResult UpdateBanner(Banner banner, IFormFile? imageFile)
        {
            var existingBanner = _context.Banners.AsNoTracking().FirstOrDefault(x => x.Id == banner.Id);

            if (existingBanner != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(existingBanner.ImageUrl))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingBanner.ImageUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    banner.ImageUrl = SaveImageFile(imageFile);
                }
                else
                {
                    banner.ImageUrl = existingBanner.ImageUrl;
                }
            }

            _context.Banners.Update(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteBanner/{id}")]
        public IActionResult DeleteBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            if (banner != null)
            {
                if (!string.IsNullOrEmpty(banner.ImageUrl))
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", banner.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                _context.Banners.Remove(banner);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private string SaveImageFile(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName);
            var imagename = Guid.NewGuid() + extension;
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bannerImages");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var savelocation = Path.Combine(folder, imagename);

            using (var stream = new FileStream(savelocation, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return "/bannerImages/" + imagename;
        }
    }
}