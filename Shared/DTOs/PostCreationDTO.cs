using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDTO
{
    public int idPost { get; }
    public int idCreator { get;  }
    public String title { get;  }

    public PostCreationDTO(int idPost, int postCreator, String title)
    {
        this.idPost = idPost;
        this.idCreator = postCreator;
        this.title = title;
    }
}