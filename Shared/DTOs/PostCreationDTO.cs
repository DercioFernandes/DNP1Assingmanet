using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public int id { get; }
    public int idCreator { get;  }
    public String title { get;  }

    public PostCreationDTO(int id, int postCreator, String title)
    {
        this.id = id;
        this.idCreator = postCreator;
        this.title = title;
    }
}