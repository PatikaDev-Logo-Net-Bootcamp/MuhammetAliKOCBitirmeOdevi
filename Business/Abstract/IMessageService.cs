using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IQueryable<Message> Messages();
        ReturnObjectDTO GetMessages(string user1, string user2);

        ReturnObjectDTO GetMessagesWithConditions(string currentUserId, string receiverUserId, int id);

        ReturnObjectDTO GetUnLookedMessageCountForUser(string currentUserId);
        
        ReturnObjectDTO AddMessage(MessageDTO message);
        ReturnObjectDTO UpdateMessageAsLooked(int id);
    }
}
