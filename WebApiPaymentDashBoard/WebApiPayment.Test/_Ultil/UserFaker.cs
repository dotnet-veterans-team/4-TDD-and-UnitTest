using Bogus;
using WebApiBankDashBoard.Model;

namespace WebApiPayment.Test._Ultil
{
    public static class UserFaker
    {
        public static User GetUser()
        {
            var fakeUserList = new Faker<User>("pt_PT")
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.ProfileId, f => f.Random.Int())
                .RuleFor(x => x.CurrentBalance, f => f.Finance.Amount(10,20))
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.AccountNumber, f => f.Finance.Iban());
            return fakeUserList.Generate();
        }
    }
}
