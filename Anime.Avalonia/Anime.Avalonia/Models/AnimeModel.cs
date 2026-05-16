namespace Anime.Avalonia.Models;

public class AnimeModel
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    // 根据你后端 JSON 再加其他字段，比如 Poster、Year、Rating 等
    // JsonSerializer 已经开了 PropertyNameCaseInsensitive，所以大小写不敏感
}