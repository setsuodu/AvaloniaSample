# Avalonia

- Anime.Avalonia
	- 播放器
		- 主工程: LibVLCSharp.Avalonia
		- Desktop:
			- Avalonia.Desktop
			- VideoLAN.LibVLC.Windows
		- Android:
			- Avalonia.Android
			- VideoLAN.LibVLC.Android
- MyXPlatApp
	- 切换界面
	- Mvvm


## 特点

- Mvvm 结构
- Postman/GitHub 一样的更新结构 Squirrel


## 编译

- PC: F5
- Android

```
adb devices
dotnet build -f net10.0-android -c Debug -t:Run
```