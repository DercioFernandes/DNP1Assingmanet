namespace Shared.DTOs;

public class SearchPostParametersDTO
{
    public int? idCreatorIs { get; }

    public SearchPostParametersDTO(int? postCreator)
    {
        this.idCreatorIs = postCreator;
    }
}