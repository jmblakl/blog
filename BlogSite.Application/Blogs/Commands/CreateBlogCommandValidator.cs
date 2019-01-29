using FluentValidation;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
