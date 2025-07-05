using NaturaStore.GCommon;

namespace NaturaStore.Web.Helpers
{
    public static class ImageHelper
    {
        public static string GetValidImageUrl(string? imageUrl)
        {
            return string.IsNullOrWhiteSpace(imageUrl)
                ? $"/images/{ApplicationConstants.NoImageUrl}"
                : imageUrl;
        }
    }
}