namespace Shared.DTOs;

public class PostUpdateDTO
{
    public int idPost { get; }
    public int idCreator { get; set; }
    public String title { get; set;  }

    public PostUpdateDTO(int idPost, int idCreator, String title)
    {
        this.idPost = idPost;
        this.title = title;
    }
}