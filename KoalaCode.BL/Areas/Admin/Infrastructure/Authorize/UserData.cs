using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KoalaCode.BL.Areas.Admin.Models.User;
using KoalaCode.DAL.KoalaCodeDB.Entities;
using Newtonsoft.Json;

namespace KoalaCode.BL.Infrastructure.Authorize
{
    public class UserData
    {
        public static LoginUserInfo GetUserInfo()
        {
            return null;
        }

        public static void SetUserInfo(User model)
        {
            var user = new LoginUserInfo
            {
                Login = model.Login,
            };

            var json = JsonConvert.SerializeObject(user);
            var userAuthCookie = new HttpCookie("UserData", json)
            {
                Expires = DateTime.Now.AddDays(1)
            };

            HttpContext.Current.Response.Cookies.Add(userAuthCookie);
        }

        public static void ClearUserInfo()
        {
            
        }
    }
}