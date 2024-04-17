using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
	public async Task<GameSummary[]> GetGamesAsync()
			=> await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

	public async Task AddGameAsync(GameDetails game)
	{
		await httpClient.PostAsJsonAsync("games", game);
	}

	public async Task<GameDetails> GetGameAsync(int id)
	{
		return await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find Game!");
	}

	public async Task UpdateGameAsync(GameDetails updatedGame)
	=> await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

	public async Task DeleteGameAsync(int id)
	=> await httpClient.DeleteAsync($"games/{id}");

	// private GameSummary GetGameSummaryById(int id)
	// {
	// 	var game = games.Find(game => game.Id == id);
	// 	ArgumentNullException.ThrowIfNull(game);
	// 	return game;
	// }

	// private Genre GetGenreById(string? id)
	// {
	// 	ArgumentException.ThrowIfNullOrWhiteSpace(id);
	// 	var genre = genres.Single(genre => genre.Id == int.Parse(id));
	// 	return genre;
	// }
}
