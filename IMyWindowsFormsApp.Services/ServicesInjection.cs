﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMyWindowsFormsApp.Services
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<ITeacherService, TeacherService>();
            service.AddScoped<IAddressService, AddressService>();
            return service;
        }
    }
}
