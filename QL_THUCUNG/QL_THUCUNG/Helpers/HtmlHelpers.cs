﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QL_THUCUNG.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsActive(this HtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;
            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];
            // must match both
            var returnActive = control == routeControl && action == routeAction;
            return returnActive ? "active" : "";
        }
    }
}