using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace projektv2
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Pole imie nie moze byc puste");

            RuleFor(x => x.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("Pole nazwisko nie moze byc puste");


            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("haslo musi zawierac co najmniej 8 znaków")
                .Must(x => x != x.ToLower())
                .WithMessage("haslo musi zawierac co najmniej 1 duza litere")
                .Must(x => x != x.ToUpper())
                .WithMessage("haslo musi zawierac co najmniej jedna mala litere")
                .Matches(@".*\d.*")
                .WithMessage("haslo musi zawierac co najmniej jedna cyfre");


            
            RuleFor(x => x.Agreement)
                .Must(x => x)
                .WithMessage("Msuisz potwierdzic ze zgadzasz sie na przetwarzanie twoich danych");
        }
    }
}
