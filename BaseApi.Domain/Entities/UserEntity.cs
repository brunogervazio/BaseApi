using BaseApi.Domain.Entities.Base;
using BaseApi.Domain.ValueObjcts;

namespace BaseApi.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        private UserEntity() { }

        public UserEntity(string name, string email, Password password)
        {
            Name = name;
            Email = new Email(email);
            Password = password;
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
    }
}