using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Entities;
using Newtonsoft.Json;

namespace KoalaCode.BL.Infrastructure.Authorize
{
    public static class UserData
    {
        public static LoginUserInfo GetUserInfo()
        {
            var userInfo = HttpContext.Current.Request.Cookies["UserData"];

            return userInfo == null ? null : JsonConvert.DeserializeObject<LoginUserInfo>(userInfo.Value);
        }

        public static void SetUserInfo(User model)
        {
            var user = new LoginUserInfo{Login = model.Login};
            var json = JsonConvert.SerializeObject(user);
            var userAuthCookie = new HttpCookie("UserData", json){Expires = DateTime.Now.AddDays(1)};

            HttpContext.Current.Response.Cookies.Add(userAuthCookie);
        }

        public static void ClearUserInfo()
        {
            var user = HttpContext.Current.Request.Cookies["UserData"];
            
            if (user == null) {return;}
            
            user.Expires = DateTime.Now.AddDays(-1);
            user.Value = null;
            
            HttpContext.Current.Response.SetCookie(user);
        }
    }
}