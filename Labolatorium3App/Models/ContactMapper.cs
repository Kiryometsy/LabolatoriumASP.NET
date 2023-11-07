using Data.Entities;

namespace Labolatorium3App.Models
{
    public class ContactMapper
    {
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                Name = model.Name,
                Email = model.Email,
                Birth = model.Birth,
                Phone = model.Phone,
                ContactId = model.Id
            };
        }

        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Name = entity.Name,
                Email = entity.Email,
                Birth = entity.Birth,
                Phone = entity.Phone,
                Id = entity.ContactId
            };
        }
    }
}
