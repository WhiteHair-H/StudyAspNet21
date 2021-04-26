﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortFolioWork.Data;
using PortFolioWork.Models;

namespace PortFolioWork.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,Name,Email,Contents")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.Regdate = DateTime.Now;
                    _context.Add(contact);
                    await _context.SaveChangesAsync();

                    ViewBag.Message = "감사합니다. 연락드리겠습니다.";
                    ModelState.Clear();
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"예외가 발생했습니다. {ex.Message}";
                }

            }
            return View();

        }
    }
}
