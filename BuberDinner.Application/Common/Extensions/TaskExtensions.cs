using ErrorOr;

namespace BuberDinner.Application.Common.Extensions
{
    public static class TaskExtensions
    {
        public static Task<ErrorOr<T>> GenerateTask<T>(ErrorOr<T> t)
        {
            return Task.FromResult<ErrorOr<T>>(t);
        }
    }
}