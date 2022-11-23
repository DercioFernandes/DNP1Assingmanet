using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public int idUser { get; set; }
    public String userName { get; set; }
    public String password { get; set; }
    
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
}