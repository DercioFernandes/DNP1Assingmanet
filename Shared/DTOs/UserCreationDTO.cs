namespace Shared.DTOs;

public class UserCreationDTO
{
    public string userName { get; }
    public string password { get; }

    public UserCreationDTO(string userName, string password)
    {
        this.userName = userName;
        this.password = password;
    }
}