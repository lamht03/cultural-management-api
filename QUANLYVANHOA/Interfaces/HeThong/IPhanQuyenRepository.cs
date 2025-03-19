using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using QUANLYVANHOA.Core.DTO;
using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces.HeThong
{
    public interface IPhanQuyenRepository
    {
        //Function Interface Repository
        Task<(IEnumerable<ChucNang>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize);
        Task<ChucNang> GetFunctionByID(int functionID);
        Task<int> CreateFunction(ChucNangInsertModel function);
        Task<int> UpdateFunction(ChucNangUpdateModel function);
        Task<int> DeleteFunction(int functionID);


        //Group Interface Repository
        Task<IEnumerable<NguoiDungTrongNhomPhanQuyenDTO>> GetAllUsersInAuthorizationGroup(int nhomPhanQuyenID);
        Task<IEnumerable<ChucNangTrongNhomPhanQuyenDTO>> GetAllFunctionsAndPermissionsInAuthorizationGroup(int groupID);
        Task<(IEnumerable<NhomPhanQuyen>, int)> GetAllGroup(string? groupName,int? officerId, int pageNumber, int pageSize);
        Task<NhomPhanQuyen> GetGroupByID(int groupID);
        Task<int> CreateGroup(NhomPhanQuyenInsertModel group);
        Task<int> UpdateGroup(NhomPhanQuyenUpdateModel group);
        Task<int> DeleteGroup(int groupID);


        //Function In Group Interface Repository
        Task<NhomChucNang> GetFunctionInGroupByID(int functionInGroupById);
        Task<int> AddFunctionToGroup(int nhomPhanQuyenID, int chucNangID, int quyen);
        Task<int> DeleteFunctionFromGroup(NhomChucNangDeleteModel model);
        Task<int> UpdateFunctionPermissionsInGroup(int nhomChucNangId, int quyen);

        Task<IEnumerable<NhomChucNang>> GetFunctionInGroupByFunctionID(int chucNangID);

        //User In Group Interface Repository
        //Task<NhomNguoiDung> GetUserInGroupByID(int userInGroupID);
        Task<IEnumerable<NhomNguoiDung>> GetUserInGroupByUserID (int userID);
        Task<int> InsertUserInGroup(ThemNguoiDungVaoNhomPhanQuyenModel userInGroup);
        Task<int> DeleteUserInGroup(XoaNguoiDungKhoiNhomPhanQuyenModel userInGroup);

    }
}
