namespace WalletAPI.Domain.Models;

public class User
{
    public string Username { get; set; } =  string.Empty;
    
    public string Password { get; set; } =  string.Empty;
    
    public string? Email { get; set; } =  string.Empty;
    
    public string? Reason { get; set; } =  string.Empty;
    
    public int Age  { get; set; } = int.MinValue;
}