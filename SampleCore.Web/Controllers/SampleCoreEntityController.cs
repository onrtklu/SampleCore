using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleCore.Core.Entities;
using SampleCore.Data.Context;
using SampleCore.Data.UnitofWork;
using SampleCore.Framework.Controller;
using SampleCore.Service.Interfaces;

namespace SampleCore.Web.Controllers
{
    public class SampleCoreEntityController : Controller
    {
        private readonly ISampleCoreService _sampleCoreService;
        public readonly ILogService _logService;
        public readonly IUnitofWork _uow;

        public SampleCoreEntityController(
            ISampleCoreService sampleCoreService,
            IUnitofWork uow,
            ILogService logService)
        {
            _sampleCoreService = sampleCoreService;
            _uow = uow;
            _logService = logService;
        }

        // GET: SampleCoreEntity
        public IActionResult Index()
        {
            var result = _sampleCoreService.GetAll();
            return View(result);
        }

        // GET: SampleCoreEntity/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleCoreEntity = _sampleCoreService.FindEntity(id);
            if (sampleCoreEntity == null)
            {
                return NotFound();
            }

            return View(sampleCoreEntity);
        }

        // GET: SampleCoreEntity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleCoreEntity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SampleCoreEntity sampleCoreEntity)
        {
            if (ModelState.IsValid)
            {
                _sampleCoreService.InsertEntity(sampleCoreEntity);
                _uow.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleCoreEntity);
        }

        // GET: SampleCoreEntity/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleCoreEntity = _sampleCoreService.FindEntity(id);
            if (sampleCoreEntity == null)
            {
                return NotFound();
            }
            return View(sampleCoreEntity);
        }

        // POST: SampleCoreEntity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SampleCoreEntity sampleCoreEntity)
        {
            if (id != sampleCoreEntity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _sampleCoreService.UpdateEntity(sampleCoreEntity);
                    _uow.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleCoreEntityExists(sampleCoreEntity.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sampleCoreEntity);
        }

        // GET: SampleCoreEntity/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleCoreEntity = _sampleCoreService.FindEntity(id);
            if (sampleCoreEntity == null)
            {
                return NotFound();
            }

            return View(sampleCoreEntity);
        }

        // POST: SampleCoreEntity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sampleCoreEntity = _sampleCoreService.FindEntity(id);
            _sampleCoreService.DeleteEntity(sampleCoreEntity);
            _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleCoreEntityExists(int id)
        {
            return _sampleCoreService.FindEntity(id) != null;
        }
    }
}
