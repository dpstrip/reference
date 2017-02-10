using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations.Interfaces;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class GetMemberFromRepositoryById : IOperation<Member>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberFromRepositoryById(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member Execute(Member member)
        {
            member = _memberRepository.Get(member.Id);

            return member;   
        }
    }
}