using MANAM.GlobalHealthCare.Business.Helpers;
using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.Common.Entities;
using MANAM.GlobalHealthCare.Model;
using MANAM.GlobalHealthCare.Repository.Interfaces;

namespace MANAM.GlobalHealthCare.Business
{
    public class MedicalEntityBusiness : IMedicalEntityBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalEntityBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MedicalEntityListViewModel> GetMedicalEntityPagedAsync(string category, int pageIndex = 0, int pageSize = 10)
        {
            var result = new MedicalEntityListViewModel { Category = category };
            pageIndex = pageIndex <= 1 ? 0 : pageIndex - 1;

            var items = await _unitOfWork.MedicalEntityRepository.GetPagedAsync(
                filter: f => !f.IsDeleted && f.Category == category,
                orderBy: o => o.OrderByDescending(d => d.Id),
                selector: s => new  MedicalEntityItemViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    AvatarUrl = s.AvatarUrl ?? string.Empty,
                    Description = s.Description,
                    Slug = s.Slug,
                    Type = s.Type
                },
                pageIndex: pageIndex,
                pageSize: pageSize
            );

            result.Paged = items;
            return result;
        }

        public async Task<bool> InsertNewMedicalEntityAsync(MedicalEntityViewModel model)
        {
            var news = new MedicalEntity
            {
                AvatarUrl = model.AvatarUrl,
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                Slug = model.Title.GenerateSlugUrl(),
                Type = model.Type,
                Category = model.Category,
                IntroForHomePage = model.IntroForHomePage
            };

            _unitOfWork.MedicalEntityRepository.Add(news);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MedicalEntityViewModel> GetDetailAsync(int id)
        {
            var data = await _unitOfWork.MedicalEntityRepository.GetByIdAsync(id);
            if (data != null)
            {
                var medicalService = new MedicalEntityViewModel
                {
                    Id = data.Id,
                    AvatarUrl = data.AvatarUrl,
                    Title = data.Title,
                    Description = data.Description,
                    Content = data.Content,
                    Category = data.Category,
                    Type = data.Type,
                    IntroForHomePage = data.IntroForHomePage
                };

                return medicalService;
            }

            return new MedicalEntityViewModel();
        }

        public async Task<bool> UpdateMedicalEntityAsync(MedicalEntityViewModel model)
        {
            var data = await _unitOfWork.MedicalEntityRepository.GetByIdAsync(model.Id);
            if (data != null)
            {
                var News = new MedicalEntity
                {
                    Id = model.Id,
                    AvatarUrl = string.IsNullOrEmpty(model.AvatarUrl) ? data.AvatarUrl : model.AvatarUrl,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Slug = model.Title.GenerateSlugUrl(),
                    Category = data.Category,
                    Type = model.Type,
                    IntroForHomePage = model.IntroForHomePage
                };

                _unitOfWork.MedicalEntityRepository.Update(News);
                return await _unitOfWork.SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> DeleteMedicalEntityAsync(int id)
        {
            var data = await _unitOfWork.MedicalEntityRepository.GetByIdAsync(id);
            if (data != null)
            {
                data.IsDeleted = true;
                _unitOfWork.MedicalEntityRepository.Update(data);
                return await _unitOfWork.SaveChangesAsync();
            }

            return false;
        }

        public async Task<MenuViewModel> GetMenuListAsync()
        {
            var result = new MenuViewModel();

            var medicalServices = await _unitOfWork.MedicalEntityRepository.GetPagedAsync(
                filter: f => !f.IsDeleted && f.Type != "Global",
                orderBy: o => o.OrderByDescending(d => d.Id),
                selector: s => new MenuItemViewModel
                {
                    Title = s.Title,
                    Url = s.Slug ?? string.Empty
                },
                pageIndex: 0,
                pageSize: 100
            );

            result.MedicalServices = medicalServices.Items.ToList();
            
            return result;
        }

        public async Task<MedicalEntityViewModel> GetMedicalEntityDetailBySlugAsync(string urlAlias)
        {
            var queryable = await _unitOfWork.MedicalEntityRepository.GetAllAsync(g => g.Slug == urlAlias && !g.IsDeleted);
            var data = queryable?.FirstOrDefault();
            if (data != null)
            {
                var medicalService = new MedicalEntityViewModel
                {
                    Id = data.Id,
                    AvatarUrl = data.AvatarUrl,
                    Title = data.Title,
                    Description = data.Description,
                    Content = data.Content,
                    Category = data.Category,
                    Type = data.Type,
                    IntroForHomePage = data.IntroForHomePage
                };

                return medicalService;
            }

            return new MedicalEntityViewModel();
        }
    }
}
