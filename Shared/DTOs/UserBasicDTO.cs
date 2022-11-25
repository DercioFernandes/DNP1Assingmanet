namespace Shared.DTOs;

public class UserBasicDTO
{
    public int idUser { get; set; }
    public string userName { get; set; }
    public string password { get; set; }

    public UserBasicDTO(int idUser,string userName, string password)
    {
        this.idUser = idUser;
        this.userName = userName;
        this.password = password;
    }
}