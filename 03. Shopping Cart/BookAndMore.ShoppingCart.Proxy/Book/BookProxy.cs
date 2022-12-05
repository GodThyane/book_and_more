using System.Text.Json;
using BookAndMore.Commons.Application.Exceptions;
using BookAndMore.ShoppingCart.Proxy.Book.DTO;
using Microsoft.Extensions.Options;

namespace BookAndMore.ShoppingCart.Proxy.Book;

public class BookProxy : IBookProxy
{
    
    private readonly ApiUrl _apiUrl;
    private readonly HttpClient _httpClient;

    public BookProxy(IOptions<ApiUrl> options, HttpClient httpClient)
    {
        _apiUrl = options.Value;
        _httpClient = httpClient;
    }

    public async Task<BookDto> GetBookAsync(int id)
    {
        try
        {
            var res = await _httpClient.GetAsync($"{_apiUrl.BookUrl}/api/v1/book/{id}");
            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookDto>(content, options);
                return result!;
            }
            throw new BadRequestException("Libro no encontrado");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}

public interface IBookProxy
{
    Task<BookDto> GetBookAsync(int id);
}