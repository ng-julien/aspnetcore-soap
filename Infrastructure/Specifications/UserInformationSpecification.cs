namespace Infrastructure.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Infrastructure.Repositories.Entities;
    using Infrastructure.Specifications.Core;

    internal interface IUserInformationSpecification : ISpecification<Person>
    {
    }

    internal class UserInformationSpecification : SpecificationBase<Person>, IUserInformationSpecification
    {
        public override Expression<Func<Person, bool>> ToExpression() => person => true;

        protected override void OnAddRelation(AddRelationship<Person> addRelationship)
        {
            base.OnAddRelation(addRelationship);

            var relationship = new Relationship<Person>(person => person.EmailAddresses);
            addRelationship(relationship);
        }
    }
}