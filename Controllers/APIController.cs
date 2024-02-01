using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using MVC.Models;

namespace MVC.Controllers;

public class APIController : Controller
{
    public async Task<IActionResult> Book(int ID)
    {
        return Ok(await GetBookData(ID));
    }

    private async Task<string> GetBookData(int id)
    {
        string apiUrl = $"https://get.taaghche.com/v2/book/{id}";
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        else
            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
    }
}
