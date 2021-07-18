using SN.Entity;
using SN.Model;

namespace SN.ClientServices.Mappers
{
    public static class RankMapper
    {
        public static RankModel ToModel(this RankEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                RequiredExperience = entity.RequiredExperience
            };
        }

        public static RankEntity ToEntity(this RankModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                RequiredExperience = model.RequiredExperience
            };
        }
    }
}