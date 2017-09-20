﻿using FtpServerUI.AppCode.Context;
using FtpServerUI.AppCode.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServerUI.AppCode.Controllers
{
    class LogController : AtmControllerBase
    {
        
        public LogController()
        {
            _context = new AtmSecureDataContext();
        }

        public LogController(JsonRequest json)
        {
            JsonRequest = json;
            _context = new AtmSecureDataContext();
        }

        public IEnumerable<object> GetAll()
        {
            var res = _context.Logs
                .Select(s => new
                {
                    s.Description,
                    s.Action,
                    s.CreatedDate,
                    s.Customer
                }).ToList();
            return res;
        }
        public void Login()
        {
            var res = _context.Customers
                .FirstOrDefault(w => w.CustomerNumber == JsonRequest.Credentials.CustomerNumber && 
                w.Pin == JsonRequest.Credentials.Pin);

            Result = res == null ? "Denegado" : "Autorizado";
            LlenarBitacora();
        }
    }
}
