using Microsoft.AspNetCore.Identity;

namespace AnimalStudio.Data.Models
{
    public class Manager
    {
        public Guid Id { get; set; }

        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        public string NickName { get; set; } = null!;
    }
}
