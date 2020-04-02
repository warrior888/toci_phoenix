using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Toci.Front.Startup))]

namespace Toci.Front
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
