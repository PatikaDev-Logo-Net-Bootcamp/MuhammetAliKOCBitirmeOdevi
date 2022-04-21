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
        List<MessageDTO> GetMessages(int SenderUserId, int ReceiverUserId);
        ReturnObjectDTO AddMessage(MessageDTO message);
        ReturnObjectDTO UpdateMessageAsLooked(int id);
    }
}
