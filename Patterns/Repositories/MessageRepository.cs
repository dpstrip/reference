using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Message Get()
        {
            return new Message
            {
                FirstName = "Craig",
                LastName = "Selbert",
                AddressLine1 = "723 Hilltop Terrace Dr",
                City = "Eureka"
            };
        }
    }
}