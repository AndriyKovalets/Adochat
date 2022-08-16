using Microsoft.AspNetCore.Identity;

namespace Adochat.Domain.Entities
{
    public class User: IdentityUser, IBaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
