namespace QUANLYVANHOA.Core.Enums
{
    [Flags]
    public enum UserPermissions
    {
        None = 0,  // 0000 - No permissions
        View = 1,  // 0001 - View access
        Add = 2,  // 0010 - Add permission
        Edit = 4,  // 0100 - Edit permission
        Delete = 8,  // 1000 - Delete permission

        FullAccess = View | Add | Edit | Delete //Aggregate All Access Rights
    }
}
