namespace Shared.Models;

public class Post
{
    public int idPost { get; set; }
    public User creator { get; set; }
    public String title { get; set; }
}