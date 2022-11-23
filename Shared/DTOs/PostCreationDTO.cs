using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public int idCreator { get;  }
    public String title { get;  }

    public PostCreationDTO(int idCreator, String title)
    {
        this.idCreator = idCreator;
        this.title = title;
    }
}