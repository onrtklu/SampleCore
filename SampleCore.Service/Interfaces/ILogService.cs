using SampleCore.Core.Entities.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCore.Service.Interfaces
{
    public interface ILogService
    {
        void InsertTempRequestLog(TempRequestLog entity);
        void InsertExceptionLog(ExceptionLog exceptionLog);
        void InsertRequestLog(RequestLog requestLog);
        void UpdateExceptionLog(ExceptionLog exceptionLog);
        ExceptionLog GetExceptionLog(int hresult);
        void InsertForbiddenExceptionLog(string email, string forbiddenType);
        object GetExceptionLogs();
    }
}
