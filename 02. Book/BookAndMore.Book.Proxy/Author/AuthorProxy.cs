using System.Text.Json;
using BookAndMore.Book.Proxy.Author.DTO;
using BookAndMore.Commons.Application.Exceptions;
using Microsoft.Extensions.Options;

namespace BookAndMore.Book.Proxy.Author;

public class AuthorProxy : IAuthorProxy
{
    private readonly ApiUrl _apiUrl;
    private readonly HttpClient _httpClient;

    public AuthorProxy(IOptions<ApiUrl> options, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiUrl = options.Value;
    }

    public async Task<AuthorBaseDto> GetAuthorAsync(int id)
    {
        try
        {
            var res = await _httpClient.GetAsync($"{_apiUrl.AuthorUrl}/api/v1/author/{id}");
            if (res.IsSuccessStatusCode) 
            {
                var content = await res.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<AuthorBaseDto>(content, options);
                return result!;
            }

            throw new BadRequestException("Autor no encontrado");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}

public interface IAuthorProxy
{
    Task<AuthorBaseDto> GetAuthorAsync(int id);
}