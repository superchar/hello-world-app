﻿using System.Web;
using System.Web.Mvc;

namespace HelloWorld.V6.Web.Read
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
