using AutoMapper;
using GraphQL.Types;

namespace StarWars.Api.Models
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class StarWarsMutation : ObjectGraphType<object>
    {
        public StarWarsMutation() { }

        public StarWarsMutation(Core.Data.IHumanRepository humanRepository, IMapper mapper)
        {
            Field<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                resolve: context =>
                {
                    var human = context.GetArgument<Human>("human");
                    var mapped = mapper.Map<Core.Models.Human>(human);
                    humanRepository.Add(mapped);
                    humanRepository.SaveChangesAsync().ConfigureAwait(false);
                    return human;
                });
        }
    }
}
