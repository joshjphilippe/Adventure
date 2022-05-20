using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game.models.player
{
    public class PlayerNameValidator : AbstractValidator<Player>
    {
        
        public PlayerNameValidator()
        {
            RuleFor(player => player.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("name is empty!")
                .Length(1, 20).WithMessage("name is too long, 20 char limit")
                .Must(BeValidName).WithMessage("name has invalid characters");
        }

        protected bool BeValidName(string name)
        {
            name = name.Replace(" ", "");
            return name.All(Char.IsLetter);
        }

    }
}
