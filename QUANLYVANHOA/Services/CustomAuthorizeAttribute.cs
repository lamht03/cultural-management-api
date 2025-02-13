using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using QUANLYVANHOA.Interfaces;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using System.Data;
using System.Collections.Generic;
using QUANLYVANHOA.Core.Enums;
using QUANLYVANHOA.Models.HeThong;
using QUANLYVANHOA.Helpers;

//public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
//{
//    private readonly Quyen _requiredPermission;
//    private readonly string _requiredFunction;

//    public CustomAuthorizeAttribute(Quyen permission, string functionName)
//    {
//        _requiredPermission = permission;
//        _requiredFunction = functionName;
//    }

//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        if (!context.HttpContext.User.Identity.IsAuthenticated)
//        {
//            context.Result = new UnauthorizedResult();
//            return;
//        }

//        // Manually resolve the service (e.g., IUserService) using HttpContext.RequestServices
//        // Giải quyết thủ công service (vd: IUserService) bằng HttpContext.RequestServices
//        var userService = context.HttpContext.RequestServices.GetService<IUserService>();

//        if (userService == null)
//        {
//            context.Result = new ForbidResult();
//            return;
//        }

//        // Lấy các claim từ token
//        var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
//        var permissionsClaim = claimsIdentity?.FindFirst("FunctionsAndPermissions");

//        if (permissionsClaim == null)
//        {
//            context.Result = new ForbidResult();
//            return;
//        }

//        // Parse JSON từ claim thành dictionary
//        var permissions = JsonConvert.DeserializeObject<Dictionary<string, Quyen>>(permissionsClaim.Value);

//        // Kiểm tra quyền của người dùng đối với chức năng yêu cầu
//        if (!permissions.ContainsKey(_requiredFunction) || !permissions[_requiredFunction].HasFlag(_requiredPermission))
//        {
//            context.Result = new ForbidResult();
//            return;
//        }
//    }


//    public static Dictionary<string, int> GetAllUserFunctionsAndPermissions(string userName)
//    {
//        var permissions = new Dictionary<string, int>();

//        //using (SqlConnection conn = new SqlConnection("Server=192.168.100.129;Database=DB_QuanLyVanHoa;User Id=The Debuggers;Password=ifyouwanttoconnectyouneedtobecomeaprofessionalprogrammer;"))
//        using (SqlConnection conn = new SqlConnection(new Connection().GetConnectionString()))

//        {
//            conn.Open();
//            SqlCommand cmd = new SqlCommand("NhomChucNang_GetAllUserFunctionsAndPermissions", conn);
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@TenNguoiDung", userName);

//            using (var reader = cmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    // Thêm chức năng và quyền vào dictionary
//                    string functionName = reader.GetString(0);
//                    int permission = reader.GetInt32(1);
//                    permissions[functionName] = permission;
//                }
//            }
//        }
//        return permissions;
//    }

//}


public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly QuyenEnums _requiredPermission;
    private readonly ChucNangEnums _requiredFunction;

    public CustomAuthorizeAttribute(QuyenEnums permission, ChucNangEnums function)
    {
        _requiredPermission = permission;
        _requiredFunction = function;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
        var permissionsClaim = claimsIdentity?.FindFirst("FunctionsAndPermissions");

        Console.WriteLine($"[DEBUG] PermissionsClaim Value: {permissionsClaim?.Value}");

        if (permissionsClaim == null || string.IsNullOrEmpty(permissionsClaim.Value))
        {
            context.Result = new ForbidResult();
            return;
        }


        // Deserialize JSON trực tiếp mà không cần Mapping lại
        var permissions = JsonConvert.DeserializeObject<Dictionary<ChucNangEnums, QuyenEnums>>(permissionsClaim.Value);

        // Log giá trị permissions để kiểm tra

        // Kiểm tra quyền
        if (!permissions.ContainsKey(_requiredFunction) || !permissions[_requiredFunction].HasFlag(_requiredPermission))
        {
            context.Result = new ForbidResult();
            return;
        }
      
    }

    //public static Dictionary<string, int> GetAllUserFunctionsAndPermissions(string userName)
    //{
    //    var permissions = new Dictionary<string, int>();

    //    //using (SqlConnection conn = new SqlConnection("Server=192.168.100.129;Database=DB_QuanLyVanHoa;User Id=The Debuggers;Password=ifyouwanttoconnectyouneedtobecomeaprofessionalprogrammer;"))
    //    using (SqlConnection conn = new SqlConnection(new Connection().GetConnectionString()))

    //    {
    //        conn.Open();
    //        SqlCommand cmd = new SqlCommand("NhomChucNang_GetAllUserFunctionsAndPermissions", conn);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@TenNguoiDung", userName);

    //        using (var reader = cmd.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                // Thêm chức năng và quyền vào dictionary
    //                string functionName = reader.GetString(0);
    //                int permission = reader.GetInt32(1);
    //                permissions[functionName] = permission;
    //            }
    //        }
    //    }
    //    return permissions;
    //}


    public static Dictionary<ChucNangEnums, QuyenEnums> GetAllUserFunctionsAndPermissions(string userName)
    {
        var permissions = new Dictionary<ChucNangEnums, QuyenEnums>();

        using (SqlConnection conn = new SqlConnection(new Connection().GetConnectionString()))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("NhomChucNang_GetAllUserFunctionsAndPermissions", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenNguoiDung", userName);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string functionName = reader.GetString(0);
                    int permissionValue = reader.GetInt32(1);

                    if (FunctionMapping.Map.TryGetValue(functionName, out var functionEnum))
                    {
                        permissions[functionEnum] = (QuyenEnums)permissionValue;
                    }
                }
            }
        }
        return permissions;
    }

}
