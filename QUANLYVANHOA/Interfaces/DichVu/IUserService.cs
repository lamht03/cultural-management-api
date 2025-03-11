using System.Threading.Tasks;

namespace QUANLYVANHOA.Interfaces.DichVu
{
    public interface IUserService
    {
        Task<(bool IsValid, string Token, string RefreshToken, string Message)> AuthenticateUser(string userName, string password);
        Task<(string Token, string RefreshToken)> RefreshToken(string refreshToken);
        public int? GetUserIdFromToken (string token);
    }
}