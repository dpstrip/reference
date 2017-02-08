using System;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Member Save(Member member)
        {
            Console.WriteLine($"Saving Member {member.FirstName}");

            return member;
        }
    }
}