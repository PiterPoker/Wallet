using Wallet.API.Models.Base;

namespace Wallet.API.Models.WalletOfFamily
{
    public record FamilyReadModel : IReadModel<long>
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public HeadMemberReadModel? HeadMember { get; init; }
    }
}
