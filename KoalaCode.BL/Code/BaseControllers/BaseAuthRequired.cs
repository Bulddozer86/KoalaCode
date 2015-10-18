using KoalaCode.BL.Attributes;
using Microsoft.AspNet.SignalR;

namespace KoalaCode.BL.Code.BaseControllers
{
    [AuthorizedUsersOnly(Constans.Roles.Admin, Constans.Roles.Moderator, Constans.Roles.User)]
    public abstract class BaseAuthRequired : BaseNoAuth
    {
    }
}