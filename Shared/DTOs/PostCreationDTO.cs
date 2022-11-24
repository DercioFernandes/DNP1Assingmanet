using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public int idUser { get;  }
    public String title { get;  }

    public PostCreationDTO(int idUser, String title)
    {
        this.idUser = idUser;
        this.title = title;
    }
}