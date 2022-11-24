namespace Shared.Models;

public class Post
{
    public int idPost { get; set; }
    public int idUser { get; set; }
    public String title { get; set; }

    public Post(int idUser, String title)
    {
        this.idUser = idUser;
        this.title = title;
    }

    public Post(int idPost, int idUser, String title)
    {
        this.idPost = idPost;
        this.idUser = idUser;
        this.title = title;
    }
}