using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.Media;

namespace Avalonia12.Android;

[Activity(
    Label = "Avalonia12.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .With(new FontManagerOptions
            {
                // 级联回退：找不到汉字时，会按照顺序从以下系统字体中尝试匹配
                FontFallbacks = new[]
                {
                    new FontFallback { FontFamily = new FontFamily("Noto Sans CJK SC") },     // 近代原生安卓标准
                    new FontFallback { FontFamily = new FontFamily("Droid Sans Fallback") }, // 经典安卓常备
                    new FontFallback { FontFamily = new FontFamily("Source Han Sans CN") },  // 部分定制 ROM
                    new FontFallback { FontFamily = new FontFamily("PingFang SC") },          // 顺便兼容 iOS/macOS
                    new FontFallback { FontFamily = new FontFamily("Microsoft YaHei") }      // 顺便兼容 Windows
                }
            });
    }
}
