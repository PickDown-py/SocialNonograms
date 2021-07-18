using SN.Entity;
using SN.Model;

namespace SN.ClientServices.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this UserEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Experience = entity.Experience,
                Likes = entity.Likes,
                Rank = entity.Rank?.ToModel()
            };
        }

        public static UserEntity ToEntity(this UserModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Experience = model.Experience,
                Likes = model.Likes,
                Rank = model.Rank.ToEntity()
            };
        }   
    }
}