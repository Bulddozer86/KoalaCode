using System.Collections.Generic;

namespace KoalaCode.BL.Areas.Admin.Models.User
{
    public class LoginUserInfo
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Roles { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); }}
    }
}