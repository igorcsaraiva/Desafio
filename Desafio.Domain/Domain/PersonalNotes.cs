using Desafio.Domain.Domain.Shared;
using System;
using System.Text;

namespace Desafio.Domain.Domain
{
    public class PersonalNotes : Entity
    {
        private string content;

        public PersonalNotes(Guid id, string content) : base(id)
        {
            Content = content;
        }

        // Entity Framework
        public PersonalNotes()
        {
        }
        public string UserId { get; set; }
        public string Content { get => content; set => content = EncryptContent(value); }

        private string EncryptContent(string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        public string DecryptContent(string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
