using FluentValidation;

namespace VTESTournamentBackend.Player.Create
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayerRequest>
    {
        public CreatePlayerValidator() 
        {
            RuleFor(x => x.Vekn).Length(7);
        }
    }
}
