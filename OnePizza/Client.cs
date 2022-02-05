namespace OnePizza;
public record Client
{
    public List<string> Likes { get; set; } = new();
    public List<string> Dislikes { get; set; } = new();
}
