using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces
{
    public interface IPermissionManagementRepository
    {
        //Function Interface Repository
        Task<(IEnumerable<HeThongChucNang>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize);
        Task<HeThongChucNang> GetFunctionByID(int functionID);
        Task<int> CreateFunction(HeThongChucNangInsertModel function);
        Task<int> UpdateFunction(HeThongChucNangUpdateModel function);
        Task<int> DeleteFunction(int functionID);


        //Group Interface Repository
        Task<(IEnumerable<HeThongNhomPhanQuyen>, int)> GetAllGroup(string? groupName, int pageNumber, int pageSize);
        Task<HeThongNhomPhanQuyen> GetGroupByID(int groupID);
        Task<int> CreateGroup(SysGroupInsertModel group);
        Task<int> UpdateGroup(NhomPhanQuyenUpdateModel group);
        Task<int> DeleteGroup(int groupID);


        //Function In Group Interface Repository
        Task<IEnumerable<HeThongNhomChucNang>> GetAllFunctionInGroup(); 
        Task<int> AddFunctionIntoGroup(NhomChucNangInsertModel functionInGroup);
        Task<int> DeleteFunctionFromGroup(int functionInGroupID);

        //User In Group Interface Repository
        Task<IEnumerable<HeThongNhomNguoiDung>> GetAllUserInGroup();
        Task<IEnumerable<HeThongNhomNguoiDung>> GetUserInGroupByGroupID(int groupID);
        Task<IEnumerable<HeThongNhomNguoiDung>> GetUserInGroupByUserID(int userID);
        Task<HeThongNhomNguoiDung> GetUserInGroupByID(int userInGroupID);
        Task<int> InsertUserInGroup(ThemNguoiDungVaoNhomPhanQuyenModel userInGroup);
        Task<int> UpdateUserInGroup(XoaNguoiDungKhoiNhomPhanQuyenModel userInGroup);
        Task<int> DeleteUserInGroup(int userInGroupID);

    }
}
