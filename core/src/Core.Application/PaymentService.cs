namespace Core.Application;

using System.Transactions;
using core.Domain;
using Core.Domain;
using Microsoft.Extensions.Logging;

// Пока до конца не разобрался как работает скоуп System.Transactions (особенно вложенных), все транзакции будут Serializable 

// TODO: оптимизировать количество запросов к БД, сейчас есть дубликаты - фиксить расширением Storage интерфейсов

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

    public async Task<UserAccount> GetAccountByUserIdAsync(Guid userId)
    {
        UserAccount? account = await _accountStorage.GetByUserIdAsync(userId);

        if (account == null)
        {
            throw new NotFoundException($"Account for {userId} not found");
        }

        return account;
    }

    public async Task<HoldAccount> GetHoldByAccountIdAsync(Guid accountId)
    {
        HoldAccount? account = await _accountStorage.GetHoldByAccountIdAsync(accountId);

        if (account == null)
        {
            throw new NotFoundException($"Account for {accountId} not found");
        }

        return account;
    }

    public async Task TransferAsync(Guid srcId, Guid destId, decimal amount)
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
            Account src = await GetAccountByIdAsync<Account>(srcId);
            Account dest = await GetAccountByIdAsync<Account>(destId);

            src.Debit(amount);
            dest.Credit(amount);

            await _accountStorage.SaveAsync(src);
            await _accountStorage.SaveAsync(dest);

            DateTimeOffset timestamp = DateTimeOffset.UtcNow;

            await CreateOperationAsync(srcId, OperationType.Debit, amount, timestamp);
            await CreateOperationAsync(destId, OperationType.Credit, amount, timestamp);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error while transfer {srcId} -> {destId}");
            throw;
        }
    }

    public async Task HoldAsync(Guid userId, decimal amount)
    {
        UserAccount account = await GetAccountByUserIdAsync(userId);
        HoldAccount hold = await GetHoldByAccountIdAsync(account.Id);

        await TransferAsync(account.Id, hold.Id, amount);
    }

    public async Task ReleaseAsync(Guid userId, decimal amount)
    {
        UserAccount account = await GetAccountByUserIdAsync(userId);
        HoldAccount hold = await GetHoldByAccountIdAsync(account.Id);

        await TransferAsync(hold.Id, account.Id, amount);
    }

    public async Task PurchaseAsync(Guid userId, decimal amount)
    {
        Account systemAccount = await _accountStorage.GetSystemAccountAsync();
        UserAccount account = await GetAccountByUserIdAsync(userId);
        HoldAccount hold = await GetHoldByAccountIdAsync(account.Id);

        await TransferAsync(hold.Id, systemAccount.Id, amount);
    }

    public async Task<UserAccount> CreateUserAccountAsync(Guid userId)
    {
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(5),
        };

        using var scope = new TransactionScope(
            TransactionScopeOption.RequiresNew,
            transactionOptions,
            TransactionScopeAsyncFlowOption.Enabled
        );

        try
        {
            UserAccount userAccount = new UserAccount(Guid.CreateVersion7(), userId);
            HoldAccount holdAccount = new HoldAccount(Guid.CreateVersion7(), userAccount.Id); 

            await _accountStorage.SaveAsync(userAccount);  
            await _accountStorage.SaveAsync(holdAccount);  

            return userAccount;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error while creating account pair for {userId}");
            throw;
        }
    }

    public async Task<decimal> GetAvailableBalanceAsync(Guid accountId)
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
            Account account = await GetAccountByIdAsync<Account>(accountId);
            Account hold = await GetHoldByAccountIdAsync(accountId);

            return account.Balance - hold.Balance;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error while fetching available balance for {accountId}");
            throw;
        }
    }

    public async Task<PaymentOperation> CreateOperationAsync(Guid accountId, OperationType op, decimal amount, DateTimeOffset timestamp)
    {
        Guid id = Guid.CreateVersion7();

        PaymentOperation operation = new PaymentOperation(id, accountId, op, amount, timestamp);

        await _operationStorage.SaveAsync(operation);

        return operation;
    }
}