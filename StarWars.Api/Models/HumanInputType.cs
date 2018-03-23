using GraphQL.Types;

namespace StarWars.Api.Models
{
    public class HumanInputType : InputObjectGraphType
    {
        public HumanInputType()
        {
            Name = "HumanInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("homePlanet");
        }
    }
}
