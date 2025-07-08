namespace Ecommerce.Shared.Constants;

public static class AuthConstants
{
    // JWT
    public const string JwtIssuer = "EcommerceAPI";
    public const string JwtAudience = "EcommerceApp";
    public const int JwtExpirationMinutes = 60;
    public const int RefreshTokenExpirationDays = 7;

    // Roles (strings para JWT claims)
    public static class Roles
    {
        public const string Customer = "customer";
        public const string Staff = "staff";
        public const string Manager = "manager";
        public const string Admin = "admin";
    }

    // Claims
    public static class Claims
    {
        public const string UserId = "user_id";
        public const string Role = "role";
        public const string Email = "email";
        public const string Provider = "auth_provider";
    }

    // OAuth Providers
    public static class Providers
    {
        public const string EmailPassword = "email_password";
        public const string Google = "google";
        public const string Apple = "apple";
        public const string Facebook = "facebook";
    }
}