﻿using IMyWindowsFormsApp.Data.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Data
{
    public static class DataInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection service)
        {
            service.AddSingleton<MyDbContext, MyDbContext>();
            return service;
        }  
    }
}
