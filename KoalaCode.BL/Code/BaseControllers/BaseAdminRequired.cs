using KoalaCode.BL.Attributes;

namespace KoalaCode.BL.Code.BaseControllers
{
    [AuthorizedUsersOnly(Constans.Roles.Admin)]
    public abstract class BaseAdminRequired : BaseNoAuth
    {
    }
}