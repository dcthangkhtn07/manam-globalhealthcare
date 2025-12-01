using MANAM.GlobalHealthCare.Model;

namespace MANAM.GlobalHealthCare.Business.Interfaces
{
    public interface IMedicalEntityBusiness
    {
        Task<bool> InsertNewMedicalEntityAsync(MedicalEntityViewModel model);

        Task<MedicalEntityListViewModel> GetMedicalEntityPagedAsync(string category, int pageIndex = 0, int pageSize = 10);

        Task<MedicalEntityViewModel> GetDetailAsync(int id);

        Task<bool> UpdateMedicalEntityAsync(MedicalEntityViewModel model);

        Task<bool> DeleteMedicalEntityAsync(int id);

        Task<MenuViewModel> GetMenuListAsync();

        Task<MedicalEntityViewModel> GetMedicalEntityDetailBySlugAsync(string urlAlias);
    }
}
