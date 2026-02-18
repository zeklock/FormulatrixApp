namespace CrudApi.Dtos;

public class PaginateRequestDto
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string? Search { get; set; } = string.Empty;
}
