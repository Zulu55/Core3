﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3.Data;
using Core3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core3.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository repository;

        public OrdersController(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.repository.GetOrdersAsync(this.User.Identity.Name);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = await this.repository.GetDetailTempsAsync(this.User.Identity.Name);
            return this.View(model);
        }

        public IActionResult AddProduct()
        {
            var model = new AddItemViewModel
            {
                Products = this.repository.GetComboProducts(),
                Quantity = 1
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddItemViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.repository.AddItemToOrderAsync(model, this.User.Identity.Name);
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }

        public async Task<IActionResult> Increase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.repository.ModifyOrderDetailTempQuantityAsync(id.Value, 1);
            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> Decrease(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.repository.ModifyOrderDetailTempQuantityAsync(id.Value, -1);
            return this.RedirectToAction("Create");
        }
    }
}