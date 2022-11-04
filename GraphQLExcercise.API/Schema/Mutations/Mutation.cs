

using GraphQLExcercise.API.Schema.Queries;

namespace GraphQLExcercise.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }
        public CourseResult CreateCourse(string name, Subject subject, Guid instructorId)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Subject = subject,
                InstructorId = instructorId
            };

            _courses.Add(courseType);
            return courseType;
        }
    }
}
