using Bogus;
using System;
using System.Collections.Generic;
using WebApiBankDashBoard.Model;

namespace WebApiPayment.Test._Ultil
{
    public static class TransactionStatmentFaker
    {
        public static IEnumerable<TransactionStatment> GetUserTransactionStatment(int numberToGenerate, string Name)
        {
            var fakeTransactionStatment = new Faker<TransactionStatment>("pt_PT")
                .RuleFor(x => x.Name, Name)
                .RuleFor(x => x.Id, f => f.Random.Int(1, 10))
                .RuleFor(x => x.Description, "TransactionStatment")
                .RuleFor(x => x.PreviousBalance, f => f.Finance.Amount(0,10))
                .RuleFor(x => x.TotalBalance, f => f.Finance.Amount(0, 10))
                .RuleFor(x => x.Withdraw, f => f.Finance.Amount(0, 10))
                .RuleFor(x => x.Date, f => f.Date.Between(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(-30)));
            return fakeTransactionStatment.Generate(numberToGenerate);
        }
    }
}
