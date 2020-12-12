using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCore.Data.UnitofWork;
using SampleCore.Framework.Enums;
using SampleCore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace SampleCore.Framework.Controller
{
    public class BaseController : ControllerBase
    {
        public readonly ILogService _logService;
        public readonly IUnitofWork _uow;
        public BaseController(
            IUnitofWork uow,
            ILogService logService)
        {
            _uow = uow;
            _logService = logService;
        }
    }
}
