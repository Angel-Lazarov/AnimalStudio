using AnimalStudio.Services.Data.Interfaces;

namespace AnimalStudio.Services.Data
{
    public class BaseService : IBaseService
    {
        public bool IsGuidValid(string? id, ref Guid parseGuid)
        {
            // Non-existing parameter in URL
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parseGuid);
            if (!isGuidValid)
            {
                return false;
            }
            return true;
        }
    }
}
