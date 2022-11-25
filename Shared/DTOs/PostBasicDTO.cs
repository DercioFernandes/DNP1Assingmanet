using Shared.Models;

namespace Shared.DTOs;

public class PostBasicDTO
{
    public int idPost { get; set; }
    public User creator { get; set; }
    public String title { get; set; }

    public PostBasicDTO(int idPost, User creator, String title)
    {
        this.idPost = idPost;
        this.creator = creator;
        this.title = title;
    }
}