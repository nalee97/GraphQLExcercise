using GraphQLExcercise.API.Schema.Queries;

namespace GraphQLExcercise.API.Schema.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
