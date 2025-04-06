using ClearView.Models;
namespace ClearView.Response;
public class AuthResult
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    }
