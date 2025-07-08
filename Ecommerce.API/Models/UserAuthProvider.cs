public class UserAuthProvider
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public AuthProviderType ProviderType { get; set; }
    public string ProviderId { get; set; } // Email, Google ID, Apple ID
    public string PasswordHash { get; set; } // Solo para email/password
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
}