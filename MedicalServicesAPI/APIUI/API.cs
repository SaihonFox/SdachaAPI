using System.Net;
using System.Net.Http;
using APIUI.Model;
using Newtonsoft.Json;

namespace APIUI;

class API
{
	public static async ValueTask<User?> Auth(string login, string password)
	{
		using var client = new HttpClient();
		var result = await client.GetAsync($"https://localhost:7122/Auth/login?login={login}&password={password}");

		if (result.StatusCode == HttpStatusCode.OK)
			return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
		return null;
	}

	public static List<Analysis> AnalysesList()
	{
		using var client = new HttpClient();
		var result = client.GetAsync("https://localhost:7122/Analyses").Result;

		return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<Analysis>>(result.Content.ReadAsStringAsync().Result)! : null!;
	}

	public static List<Analysis> AddAnalysis(Analysis? analysis)
	{
		using var client = new HttpClient();
		var result = client.PostAsync("https://localhost:7122/Analyses", new StringContent(JsonConvert.SerializeObject(analysis))).Result;

		return result.StatusCode == HttpStatusCode.Created ? JsonConvert.DeserializeObject<List<Analysis>>(result.Content.ReadAsStringAsync().Result)! : null!;
	}

	public static List<AnalysisCategory> CategoryList()
	{
		using var client = new HttpClient();
		var result = client.GetAsync("https://localhost:7122/Categories").Result;

		return result.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<List<AnalysisCategory>>(result.Content.ReadAsStringAsync().Result)! : null!;
	}
}