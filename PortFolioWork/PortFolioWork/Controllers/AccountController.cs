using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortFolioWork.Data;
using PortFolioWork.Models;

namespace PortFolioWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account
        public IActionResult Login()
        {
            var account = new Account();
            return View(account);

        }
        
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                var result = checkAccount(account.Email, account.Password);
                if (result == null)
                {
                    // 계정이 없을 경우 화면을 Home/Index 이동
                    ViewBag.Message = "해당계정이 없습니다";
                    return View("Login");
                }
                else
                {
                    // 로그인
                    HttpContext.Session.SetString("UserEmail",result.Email );
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Login");
        }

        private Account checkAccount(string email, string password)
        {
            return _context.Accounts.SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
