using FluentValidation;

namespace BlogSite.Application.Posts.Commands
{
    public sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(c => c.Content).NotEmpty().MinimumLength(300);
            RuleFor(c => c.Title).NotEmpty().MaximumLength(50);            
        }
    }
}
