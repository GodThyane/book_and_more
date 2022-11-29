namespace BookAndMore.Gateway.Remote;

public class RemoteBookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public object Author { get; set; } = new();
    public DateTime? PublishedDate { get; set; }
}