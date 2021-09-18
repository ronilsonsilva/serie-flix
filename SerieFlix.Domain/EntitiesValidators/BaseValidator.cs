using FluentValidation;
using SerieFlix.Domain.Entities;

namespace SerieFlix.Domain.EntitiesValidators
{
    public class BaseValidator<TEntity> : AbstractValidator<TEntity> where TEntity : EntityBase
    {

    }

    public interface IDomainEntitiesValidator
    {

    }
}
