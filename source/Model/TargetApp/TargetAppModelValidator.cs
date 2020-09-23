using FluentValidation;

namespace Architecture.Model
{
    public sealed class TargetAppModelValidator : AbstractValidator<TargetAppModel>
    {
        public TargetAppModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.Interval).NotEmpty();
        }
    }
}
