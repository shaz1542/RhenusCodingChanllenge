
using GameOfLuck.Application.Common.Interfaces;

namespace GameOfLuck.Application.Players.Queries;
public class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
{
    private readonly IApplicationDbContext _context;
    public GetPlayerByIdQueryValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(v => v.Id)
               .MustAsync(PlayerExist)
                .WithMessage("'{PropertyName}' Does not exist")
                .WithErrorCode("Invalid {PropertyName}");

    }
    private async Task<bool> PlayerExist(int gameId, CancellationToken token)
    {
        return (await _context.Players.Where(x => x.Id == gameId).FirstOrDefaultAsync()) != null ? true : false;
    }
}
