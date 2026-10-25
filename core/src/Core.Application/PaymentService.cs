using System.Transactions;
using Core.Domain;
using Microsoft.Extensions.Logging;

namespace Core.Application;

public class PaymentService
{
    private readonly IPaymentOperationStorage _operationStorage;
    private readonly IAccountStorage _accountStorage;
    private readonly ILogger _logger;

    public PaymentService(
        IPaymentOperationStorage operationStorage,
        IAccountStorage accountStorage,
        ILogger logger
    )
    {
        _operationStorage = operationStorage;
        _accountStorage = accountStorage;
        _logger = logger;
    }

    public async Task<T> GetAccountByIdAsync<T>(Guid id) where T : Account
    {
        T? account = await _accountStorage.GetByIdAsync<T>(id);

        if (account == null)
        {
            throw new NotFoundException($"Account {id} not found");
        }

        return account;
    }

    public async Task TransferAsync(Guid srcId, Guid destId, decimal amount, Guid op1, Guid op2, DateTimeOffset timestamp)
    {
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.Serializable,
            Timeout = TimeSpan.FromSeconds(5),
        };

        using var scope = new TransactionScope(
            TransactionScopeOption.Required,
            transactionOptions,
            TransactionScopeAsyncFlowOption.Enabled
        );

        try
        {
            Account? src = await GetAccountByIdAsync<Account>(srcId);
            Account? dest = await GetAccountByIdAsync<Account>(destId);

            src.Debit(amount);
            dest.Credit(amount);

            await CreateOperationAsync(op1, srcId, OperationType.Debit, amount, timestamp);
            await CreateOperationAsync(op2, destId, OperationType.Credit, amount, timestamp);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while transfer");
            throw;
        }
    }

    public async Task CreateOperationAsync(Guid id, Guid accountId, OperationType op, decimal amount, DateTimeOffset timestamp)
    {
        PaymentOperation operation = new PaymentOperation(id, accountId, op, amount, timestamp);

        await _operationStorage.SaveAsync(operation);
    }
}