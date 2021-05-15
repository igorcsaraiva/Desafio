using Desafio.Domain.Domain.Shared;
using System;

namespace Desafio.Domain.Domain
{
    public class UserInfo : Entity
    {
        public UserInfo(Guid id, string name, string homeTown) : base(id)
        {
            Name = name;
            HomeTown = homeTown;
        }

        // Entity Framework
        public UserInfo()
        {
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string HomeTown { get; set; }
    }
}
