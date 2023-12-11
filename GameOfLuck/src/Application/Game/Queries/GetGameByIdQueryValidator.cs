using GameOfLuck.Application.Common.Interfaces;


namespace GameOfLuck.Application.Game.Queries;
public class GetPlayerByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    private readonly IApplicationDbContext _context;
    public GetPlayerByIdQueryValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(v => v.Id)
               .MustAsync(GameExist)
                .WithMessage("'{PropertyName}' Does not exist")
                .WithErrorCode("Invalid {PropertyName}");

    }
    private async Task<bool> GameExist(int gameId, CancellationToken token)
    {
        return (await _context.Games.Where(x => x.Id == gameId).FirstOrDefaultAsync()) != null ? true : false;
    }
}
