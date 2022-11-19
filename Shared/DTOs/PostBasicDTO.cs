namespace Shared.DTOs;

public class PostBasicDTO
{
    public int idPost { get; }
    public int idCreator { get; }
    public String title { get; }

    public PostBasicDTO(int idPost, int idCreator, String title)
    {
        this.idPost = idPost;
        this.idCreator = idCreator;
        this.title = title;
    }
}