using WalletAPI.Application.DTOs;

namespace WalletAPI.Application.ServiceInterfaces;

public interface ISearchFeatureService
{
    Task<List<TransactionDto>> GetNativeTransactionsAsync (string address, int limit, string chain = "eth", string order = "DESC");
}