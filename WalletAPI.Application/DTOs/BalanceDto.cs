namespace WalletAPI.Application.DTOs;

public class BalanceDto
{
    public string Token_Address { get; set; }

    public string Name { get; set; }

    public string Symbol { get; set; }

    public int Decimals { get; set; }

    public string Balance { get; set; }

    public bool Possible_Spam { get; set; }

    public bool Verified_Contract { get; set; }
}