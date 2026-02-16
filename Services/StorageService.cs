using System.Text.Json;
using Microsoft.JSInterop;
using Yahtzee.Models;

namespace Yahtzee.Services;

public class StorageService
{
    private readonly IJSRuntime _jsRuntime;
    private const string StorageKey = "yahtzee_games";

    public StorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<List<Game>> LoadGamesAsync()
    {
        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            if (string.IsNullOrEmpty(json))
                return new List<Game>();

            return JsonSerializer.Deserialize<List<Game>>(json) ?? new List<Game>();
        }
        catch
        {
            return new List<Game>();
        }
    }

    public async Task SaveGameAsync(Game game)
    {
        var games = await LoadGamesAsync();
        var existingGame = games.FirstOrDefault(g => g.Id == game.Id);

        if (existingGame != null)
        {
            games.Remove(existingGame);
        }

        games.Add(game);
        await SaveAllGamesAsync(games);
    }

    public async Task DeleteGameAsync(Guid id)
    {
        var games = await LoadGamesAsync();
        games.RemoveAll(g => g.Id == id);
        await SaveAllGamesAsync(games);
    }

    public async Task<Game?> GetGameAsync(Guid id)
    {
        var games = await LoadGamesAsync();
        return games.FirstOrDefault(g => g.Id == id);
    }

    private async Task SaveAllGamesAsync(List<Game> games)
    {
        var json = JsonSerializer.Serialize(games);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
    }
}
