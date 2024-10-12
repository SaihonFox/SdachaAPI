using System.Net;
using System.Net.Http;
using APIUI.Model;
using Newtonsoft.Json;

namespace APIUI;

class API
{
	public static async ValueTask<user?> Auth(string login, string password)
	{
		using var client = new HttpClient();
		var result = await client.GetAsync($"https://localhost:7122/Auth/login?login={login}&password={password}");

		if (result.StatusCode == HttpStatusCode.OK)
			return JsonConvert.DeserializeObject<user>(await result.Content.ReadAsStringAsync());
		return null;
	}
}