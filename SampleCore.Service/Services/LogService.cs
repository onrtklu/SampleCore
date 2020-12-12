using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SampleCore.Core.Entities.Log;
using SampleCore.Data.UnitofWork;
using SampleCore.Service.Abstracts;
using SampleCore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCore.Service.Services
{
    public class LogService : ALogService, ILogService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActionContextAccessor _actionContextAccessor;

        public LogService(IUnitofWork uow, IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionContextAccessor) : base(uow) 
        {
            _httpContextAccessor = httpContextAccessor;
            _actionContextAccessor = actionContextAccessor;
        }

        public void InsertRequestLog(RequestLog requestLog)
        {
            _requestLogRepository.Insert(requestLog);
        }
        public void InsertTempRequestLog(TempRequestLog entity)
        {
            _tempRequestLogRepository.Insert(entity);
        }
        public void InsertExceptionLog(ExceptionLog exceptionLog)
        {
            _exceptionLogRepository.Insert(exceptionLog);
        }
        public void UpdateExceptionLog(ExceptionLog exceptionLog)
        {
            _exceptionLogRepository.Update(exceptionLog);
        }
        public ExceptionLog GetExceptionLog(int hresult)
        {
            return _exceptionLogRepository.GetAll().Where(p => p.HResult == hresult).SingleOrDefault();
        }
        public void InsertForbiddenExceptionLog(string email, string forbiddenType)
        {
            var req = _httpContextAccessor.HttpContext.Request;
            var aca = _actionContextAccessor?.ActionContext;
            var exceptionLog = new ExceptionLog
            {
                BrowserInfo = req?.Headers["User-Agent"].ToString(),
                CreatedBy = email,
                CreatedDate = DateTime.Now,
                ExceptionUrl = aca?.RouteData?.Values["controller"]?.ToString() + "/" + aca?.RouteData?.Values["action"]?.ToString(),
                IpAdress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                IsForbidden = true,
                Message = forbiddenType,
                RequestId = null
            };
            _exceptionLogRepository.Insert(exceptionLog);
        }
        public object GetExceptionLogs()
        {
            //var result = (from a in _personRepository.GetAll()
            //              join b in _exceptionLogRepository.GetAll() on a.Id equals b.CreatedBy
            //              orderby b.CreatedDate descending
            //              select new
            //              {
            //                  Fullname = a.Name + " " + a.Surname,
            //                  b.IpAdress,
            //                  b.Message,
            //                  b.ExceptionUrl,
            //                  b.HResult,
            //                  b.CreatedDate,
            //                  b.ErrorCount,
            //              }).ToList().Select(p => new
            //              {
            //                  p.Fullname,
            //                  p.IpAdress,
            //                  p.Message,
            //                  p.ExceptionUrl,
            //                  p.HResult,
            //                  p.ErrorCount,
            //                  CreatedDate = p.CreatedDate.ToString("dd.MM.yyyy HH:mm"),
            //              }).ToList();
            //return result;
            return null;
        }
    }
}
