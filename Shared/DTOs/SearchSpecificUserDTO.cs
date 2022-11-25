namespace Shared.DTOs;

public class SearchSpecificUserDTO
{
    public int idUser { get; }

    public SearchSpecificUserDTO(int idUser)
    {
        this.idUser = idUser;
    }
}