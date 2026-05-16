using System.Collections.Generic;

namespace Anime.Avalonia.Models;

public class AnimeModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string JapaneseTitle { get; set; }

    public string EnglishTitle { get; set; }

    public string Episodes { get; set; }

    public string CoverUrl { get; set; }

    public string SourceFingerprint { get; set; }

    public string PlayUrls { get; set; }

    public string BackupUrls { get; set; }

    public int Year { get; set; } // 存储年份（如 2026）

    public string Area { get; set; }

    public string Category { get; set; }

    public System.DateTime UpdateTime { get; set; }
}