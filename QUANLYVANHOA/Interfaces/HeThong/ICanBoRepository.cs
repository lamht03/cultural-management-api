using QUANLYVANHOA.Models.HeThong;

namespace QUANLYVANHOA.Interfaces.HeThong
{
    public interface ICanBoRepository
    {
        Task<(IEnumerable<CanBo>,int)> CanBoGetListPaging(string? tenCanBo,int? coQuanID, int pageNumber, int pageSize);

        Task<CanBo> CanBoGetByID(int canBoID);
        Task<int> CanBoAdd (CanBoAddModel canBoAddModel);
        Task<int> CanBoUpdate(CanBoUpdateModel canBoUpdateModel);
        Task<CanBo> CanBoGetByEmail(string email);
        Task<CanBo> CanBoGetByName(string tenCanBo);
        Task<int> CanBoDelete(int canBoId);

    }
}
