using System;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Member Get(int id)
        {
            return new Member
            {
                Id = id,
                FirstName = "Craig",
                LastName = "Selbert",
                CreateUser = "Ken",
                CreateDate = DateTime.UtcNow.AddDays(-7)
            };
        }

        public Member Save(Member member)
        {
            Console.WriteLine($"Saving Member {member.FirstName}");

            return member;
        }
    }
}