using Wallet.Domain.Models.Enumes;
using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Models.BaseEntity;

public abstract class FinancialBase(long id, decimal balance, Currency currency) : Entity<long>(id)
{
    public decimal Balance { get; protected set; } = balance;
    public Currency Currency { get;  protected set; } = currency;

    public virtual void ChangeCurrency(Currency currency)
    {
        if (Balance != 0)
            throw new AggregateException("Balance must be 0");
        
        Currency = currency <= 0 ? currency : throw new AggregateException("ID must be greater than 0");
    }

    public virtual void AddMoney(decimal amount)
    {
        Balance += amount >= 0 ? amount : throw new AggregateException("Money must be greater than 0");
    }
    
    /// <summary>
    /// Списать деньги со счета
    /// </summary>
    /// <param name="amount">сумма</param>
    /// <exception cref="AccountException">Ошибка при выполнение списания</exception>
    public virtual void WriteOffMoney(decimal amount)
    {
        if (amount < 0)
            throw new AggregateException($"Property {nameof(amount)} cannot be negative");
        
        if (amount > Balance)
            throw new AggregateException($"Property {nameof(amount)} cannot be greater than balance");
        
        Balance -= amount;
    }
}