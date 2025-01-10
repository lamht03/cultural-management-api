using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces
{
    public interface IPermissionManagementRepository
    {
        //Function Interface Repository
        Task<(IEnumerable<SysFunction>, int)> GetAllFunction(string? functionName, int pageNumber, int pageSize);
        Task<SysFunction> GetFunctionByID(int functionID);
        Task<int> CreateFunction(SysFunctionInsertModel function);
        Task<int> UpdateFunction(SysFunctionUpdateModel function);
        Task<int> DeleteFunction(int functionID);


        //Group Interface Repository
        Task<(IEnumerable<SysGroup>, int)> GetAllGroup(string? groupName, int pageNumber, int pageSize);
        Task<SysGroup> GetGroupByID(int groupID);
        Task<int> CreateGroup(SysGroupInsertModel group);
        Task<int> UpdateGroup(SysGroupUpdateModel group);
        Task<int> DeleteGroup(int groupID);


        //Function In Group Interface Repository
        Task<IEnumerable<SysFunctionInGroup>> GetAllFunctionInGroup(); 
        Task<IEnumerable<SysFunctionInGroup>> GetFunctionInGroupByGroupID(int groupID);
        Task<IEnumerable<SysFunctionInGroup>> GetFunctionInGroupByFunctionID(int functionID);
        Task<SysFunctionInGroup> GetFunctionInGroupByID(int functionInGroupID);
        Task<int> InsertFunctionInGroup(SysFunctionInGroupInsertModel functionInGroup);
        Task<int> UpdateFunctionInGroup(SysFunctionInGroupUpdateModel functionInGroup);
        Task<int> DeleteFunctionInGroup(int functionInGroupID);

        //User In Group Interface Repository
        Task<IEnumerable<SysUserInGroup>> GetAllUserInGroup();
        Task<IEnumerable<SysUserInGroup>> GetUserInGroupByGroupID(int groupID);
        Task<IEnumerable<SysUserInGroup>> GetUserInGroupByUserID(int userID);
        Task<SysUserInGroup> GetUserInGroupByID(int userInGroupID);
        Task<int> InsertUserInGroup(SysUserInGroupCreateModel userInGroup);
        Task<int> UpdateUserInGroup(SysUserInGroupUpdateModel userInGroup);
        Task<int> DeleteUserInGroup(int userInGroupID);

    }
}
