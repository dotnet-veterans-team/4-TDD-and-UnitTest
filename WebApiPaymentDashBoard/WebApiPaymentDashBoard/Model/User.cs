using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace WebApiBankDashBoard.Model
{
    [ExcludeFromCodeCoverage]
    [Container("users")]
    [PartitionKeyPath("/profileId")]
    public class User : Item
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public decimal CurrentBalance { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public string AccountNumber { get; set; }
    }
}
