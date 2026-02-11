using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WalletAPI.Domain.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WalletAPI.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionHistoryController : ControllerBase
{
    
    private IConfiguration _config;
    // Replace to add parameters on to it later to make it more dynamic
    private readonly string _apiBaseUrl = "https://deep-index.moralis.io/api/v2.2/wallets/0xcB1C1FdE09f811B294172696404e88E658659905/history?chain=eth&order=DESC&limit=25";

    private readonly HttpClient _client;

    private record ErrorResponse(int Status, string Content, string UriUsed);

    private record GoodRequest(string originalData, Level1 ParsedData);

    private record Level1(int pageSize, int page, int limit, List<TransactionDto> result);

    private record TransactionDto(string hash);

    public TransactionHistoryController(IConfiguration config)
    {
        _client = new HttpClient();
        _config = config;
        
        _client.BaseAddress = new Uri(_apiBaseUrl);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Add("X-API-Key",_config["WalletAPI:ApiKey"]);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }


    [HttpGet("getrawjson")]
    public async Task<IActionResult> GetRawJson()
    {
        
        var response = await _client.GetAsync(_apiBaseUrl);
        var data = string.Empty;

        if (response.IsSuccessStatusCode)
        {
            data = await response.Content.ReadAsStringAsync();
            
        }
        else
        {
            return BadRequest(new ErrorResponse(
                (int)response.StatusCode,
                response.Content.ReadAsStringAsync().Result,
                response.Headers.ToString()) );
        }
        
        return Ok(data);
    }
    
    [HttpGet("getparsejson")]
    public async Task<IActionResult> GetParseJson()
    {
        
        var response = await _client.GetAsync(_apiBaseUrl);
        var data = string.Empty;
        Level1 transactions;

        if (response.IsSuccessStatusCode)
        {
            data = await response.Content.ReadAsStringAsync();
            transactions = JsonConvert.DeserializeObject<Level1>(data);

        }
        else
        {
            return BadRequest(new ErrorResponse(
                (int)response.StatusCode,
                response.Content.ReadAsStringAsync().Result,
                response.Headers.ToString()) );
        }
        
        return Ok(new GoodRequest(data, transactions));
    }

    [HttpGet("gettransactions")]
    public async Task<ActionResult> GetTransactions()
    {
        List<TransactionHistory> transactions;

        var responseMessage = await _client.GetAsync(_apiBaseUrl);

        if (responseMessage.IsSuccessStatusCode)
        {
            var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            transactions = JsonConvert.DeserializeObject<List<TransactionHistory>>(responseData);
        }
        else
        {
            throw new HttpRequestException(responseMessage.ReasonPhrase);
        }
        

        return Ok(transactions);
    }
}