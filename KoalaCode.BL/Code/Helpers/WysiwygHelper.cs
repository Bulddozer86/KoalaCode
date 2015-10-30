using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace KoalaCode.BL.Code.Helpers
{
    public static class WysiwygHelper
    {
        public static MvcHtmlString Wysiwyg(this HtmlHelper helper, string id)
        {
            return MvcHtmlString.Create("");
        } 
    }

  
}