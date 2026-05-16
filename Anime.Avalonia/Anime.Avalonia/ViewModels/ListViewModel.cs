using Anime.Avalonia.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anime.Avalonia.ViewModels;

public partial class ListViewModel : ViewModelBase
{
    private readonly MainViewModel _mainVm;

    [ObservableProperty]
    private ObservableCollection<AnimeModel> animes = new();

    [ObservableProperty]
    private AnimeModel? selectedItem;        // ← 必须是 AnimeModel

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string status = "准备加载...";

    [ObservableProperty]
    private string? searchText;

    public ListViewModel(MainViewModel mainVm)
    {
        _mainVm = mainVm;
        LoadAnimesAsync();                    // 自动加载
    }

    [RelayCommand]
    private async Task LoadAnimesAsync()
    {
        IsLoading = true;
        Status = "正在请求...";

        try
        {
            string baseUrl = "http://192.168.1.198:8060";
            string url = $"{baseUrl}/api/netflix?page=1&pageSize=60&search={SearchText ?? ""}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<AnimeModel>>(json, options);

            if (list != null && list.Count > 0)
                Debug.WriteLine($"✅ 第一部番剧名字: {list[0].Title}");

            Animes.Clear();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                    Animes.Add(item);

                Status = $"共{Animes.Count}部。第一部：{Animes[0].Title ?? "null"}";
            }
            else
            {
                Status = "加载完成，但返回列表为空。";
            }
        }
        catch (Exception ex)
        {
            Status = $"请求失败: {ex.Message}";
            Debug.WriteLine($"❌ {ex}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private static readonly HttpClient _httpClient = new HttpClient();

    // ★★★ 修复后的点击方法 ★★★
    partial void OnSelectedItemChanged(AnimeModel? value)
    {
        if (value != null)
        {
            System.Diagnostics.Debug.WriteLine($">>> [LOG] 点击了: {value.Title}");
            _mainVm.GoToDetail(value);
            SelectedItem = null;   // 必须置空
        }
    }

    [RelayCommand]
    private void Search()
    {
        _ = LoadAnimesAsync();
    }
}