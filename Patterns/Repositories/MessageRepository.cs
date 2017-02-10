using UMV.Reference.Patterns.Models;
using UMV.Reference.Patterns.Repositories.Interfaces;

namespace UMV.Reference.Patterns.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Message Get(int id)
        {
            return new Message
            {
                Id = id,
                FirstName = "Craig One",
                LastName = "Selbert One",
                AddressLine1 = "723 Hilltop Terrace Dr",
                City = "Eureka"
            };
        }
    }
}