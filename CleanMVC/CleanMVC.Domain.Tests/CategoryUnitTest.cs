using CleanMVC.Domain.Entities;
using FluentAssertions;

namespace CleanMVC.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Negative Id Value")]
        public void CreateCategory_NegatiIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Category With null name invalid")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Category With minumun characters")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Validation.DomainExceptionValidation>().WithMessage("Invalid name: minimun 3 characters");
        }

        [Fact(DisplayName = "Create Category With empty name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name: name is required");
        }
    }
}
