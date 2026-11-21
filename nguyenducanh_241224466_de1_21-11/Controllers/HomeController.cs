using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nguyenducanh_241224466_de1_21_11.Models;
using System.Diagnostics;

namespace nguyenducanh_241224466_de1_21_11.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _db;

        public HomeController(QLTaiSanContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TieuDe = "Nguyễn Đức Anh";
            var ds = await _db.TaiSans
                .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
            return View(ds);
        }

        public async Task<IActionResult> TaiSanTheoLoai(int maLoai)
        {
            ViewBag.TieuDe = (await _db.LoaiTaiSans.FindAsync(maLoai))?.TenLoai;
            var ds = await _db.TaiSans
                .Where(t => t.MaLoai == maLoai)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
            return PartialView("NguyenDucAnh_MainContent", ds);
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
    }
}