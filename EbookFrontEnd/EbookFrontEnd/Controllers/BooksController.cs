using EbookFrontEnd.ViewModels.BooksVm;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EbookFrontEnd.Controllers;

public class BooksController : Controller
{
    private  readonly HttpClient _httpClient;
  

    public BooksController(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5102/api/");
    }

      [HttpGet] 
    public async Task<IActionResult> GetAllBooks(int pageNumber = 1, int pageSize = 3)
    {
        var response = await _httpClient.GetAsync($"Book?page={pageNumber}&pageSize={pageSize}");
        if (!response.IsSuccessStatusCode)
        {
            return View("Error");
        }

        var content = await response.Content.ReadAsStringAsync();
        var apiResult = JsonConvert.DeserializeObject<BookResponseVm>(content);

        return PartialView(apiResult);
    }

        
    
}