

namespace CManager.Domain.Helpers
{
    public class GuidGenerator
    {
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
