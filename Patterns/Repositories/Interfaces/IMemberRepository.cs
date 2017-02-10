using UMV.Reference.Patterns.Models;

namespace UMV.Reference.Patterns.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Member Get(int id);

        Member Save(Member member);
    }
}