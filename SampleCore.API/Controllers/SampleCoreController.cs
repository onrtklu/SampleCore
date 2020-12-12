using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCore.Core.Entities;
using SampleCore.Data.UnitofWork;
using SampleCore.Framework.Controller;
using SampleCore.Service.Interfaces;

namespace SampleCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleCoreController : BaseController
    {
        private readonly ISampleCoreService _sampleCoreService;

        public SampleCoreController(
            ISampleCoreService sampleCoreService, 
            IUnitofWork uow,
            ILogService logService) : base(uow, logService)
        {
            _sampleCoreService = sampleCoreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _sampleCoreService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _sampleCoreService.FindEntity(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(SampleCoreEntity entity)
        {
            _sampleCoreService.InsertEntity(entity);
            _uow.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(SampleCoreEntity entity)
        {
            _sampleCoreService.UpdateEntity(entity);
            _uow.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(SampleCoreEntity entity)
        {
            _sampleCoreService.DeleteEntity(entity);
            _uow.SaveChanges();
            return Ok();
        }


    }
}
