using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Operations
{
    public interface IOperation<T>
    {
        T Execute(T context);
    }

    public class AddMemberNameOperation : IOperation<Member>
    {

        public AddMemberNameOperation()
        {
            
        }
        public Member Execute(Member context)
        {
            context.FirstName = "Craig";

            return context;
        }
    }
}