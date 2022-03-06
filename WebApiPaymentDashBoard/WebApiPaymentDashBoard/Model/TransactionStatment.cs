using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace WebApiBankDashBoard.Model
{
    [ExcludeFromCodeCoverage]
    [Container("transaction")]
    [PartitionKeyPath("/Id")]
    public class TransactionStatment : Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PreviousBalance { get; set; }

        public decimal TotalBalance { get; set; }

        public decimal Withdraw { get; set; }

        public  DateTime CreatedDate { get; set; }

        public  DateTime Date { get; set; }
    }
}
