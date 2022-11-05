using GraphQLExcercise.API.Schema.Mutations;
using GraphQLExcercise.API.Schema.Queries;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace GraphQLExcercise.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{courseId}_{nameof(Subscription.CourseUpdated)}";

            return topicEventReceiver.SubscribeAsync<string, CourseResult>(topicName);
        }
    }
}
