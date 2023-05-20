﻿using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyReselvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection servceCollection)
        {
            servceCollection.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        }
    }
}
