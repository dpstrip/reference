using System.Collections.Generic;
using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Operations.Interfaces;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Operations
{
    public class UpdateMemberFromMessageOperation : IOperation<Member>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateMemberFromMessageOperation(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Member Execute(Member member)
        {
            var message = _messageRepository.Get(member.Id);

            member.FirstName = message.FirstName;
            member.LastName = message.LastName;

            member.Addresses = new List<Address>
            {
                new Address
                {
                    AddressLine1 = message.AddressLine1,
                    City = message.City
                }
            };

            return member;
        }
    }
}