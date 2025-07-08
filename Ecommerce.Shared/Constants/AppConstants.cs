namespace Ecommerce.Shared.Constants
{
    public static class AppConstants
    {
        // Pagination
        public const int DefaultPageSize = 20;
        public const int MaxPageSize = 100;

        // File uploads
        public const int MaxImageSizeBytes = 5 * 1024 * 1024; // 5MB
        public const string[] AllowedImageTypes = { ".jpg", ".jpeg", ".png", ".webp" };

        // Business
        public const decimal MinOrderAmount = 10000; // $10.000 COP
        public const decimal FreeShippingThreshold = 50000; // $50.000 COP

        // Cache keys
        public static class CacheKeys
        {
            public const string Categories = "categories";
            public const string FeaturedProducts = "featured_products";
            public const string Promotions = "active_promotions";
        }
    }
}
