using ClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClaimSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ClaimSystemDBContext _claimSystemDBContext;
        public HomeController(ILogger<HomeController> logger, ClaimSystemDBContext claimSystemDBContext)
        {
            _logger = logger;
            _claimSystemDBContext = claimSystemDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewClaims()
        {
            var allClaims = _claimSystemDBContext.claims.ToList();
            return View(allClaims);
        }

        public IActionResult Form()
        {
            return View();
        }
        public IActionResult PR_Review()
        {
            var allClaims = _claimSystemDBContext.claims.ToList();
            return View(allClaims);
        }

        public IActionResult Approve(string id)
        {
            var claimApr = _claimSystemDBContext.claims.SingleOrDefault(o => o.ID==id);
            claimApr.Status = "Approved";
            _claimSystemDBContext.Update(claimApr);
            _claimSystemDBContext.SaveChanges();
            return RedirectToAction("PR_Review");
        }

        public IActionResult Reject(string id)
        {
            var claimApr = _claimSystemDBContext.claims.SingleOrDefault(o => o.ID == id);
            claimApr.Status = "Rejected";
            _claimSystemDBContext.Update(claimApr);
            _claimSystemDBContext.SaveChanges();
            return RedirectToAction("PR_Review");
        }
        public IActionResult ClaimForm(Claim claim)
        {
            claim.ID = $"{new Random().Next(10000,100000)}";
            claim.Date = DateTime.Now;
            claim.Status = "Pending";
            double tot = claim.HourlyRate * claim.HoursWorked;
            claim.Total = tot;
            _claimSystemDBContext.Add(claim);
            _claimSystemDBContext.SaveChanges();
            return RedirectToAction("ViewClaims");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
