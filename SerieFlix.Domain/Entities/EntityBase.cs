using FluentValidation.Results;

namespace SerieFlix.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public bool Invalid => !Valid;
        public bool Valid => this.Validate().IsValid;

        public abstract ValidationResult Validate();
    }
}
