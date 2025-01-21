namespace QUANLYVANHOA.Core.Enums
{
    [Flags]
    public enum Quyen
    {
        Xem = 1,  // 0001 - View access
        Them = 2,  // 0010 - Add permission
        Sua = 4,  // 0100 - Edit permission
        Xoa = 8,  // 1000 - Delete permission
    }
}
