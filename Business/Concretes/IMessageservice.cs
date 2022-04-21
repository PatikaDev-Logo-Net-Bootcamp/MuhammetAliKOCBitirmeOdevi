using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using EntityFramework.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> repository;
        private readonly IUnitOfWork unitOfWork;

        public MessageService(IRepository<Message> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Message> Messages()
        {
            return repository.GetAll();
        }

        public List<MessageDTO> GetMessages(int SenderUserId, int ReceiverUserId)
        {
            var messages = Messages()
                .Select(x => new MessageDTO()
                {
                    Id = x.Id,
                    Text = x.Text,
                    DateCreated = x.DateCreated,
                    IsLooked = x.IsLooked,
                    SendUserId = x.SendUserId,
                    ReceiveUserId = x.ReceiveUserId

                }).ToList();
            return messages;
        }
  
        public ReturnObjectDTO AddMessage(MessageDTO message)
        {
            try
            { 
                var messageEntity = new Message()
                {
                    Id = message.Id,
                    Text = message.Text,
                    DateCreated = message.DateCreated,
                    IsLooked = false,
                    SendUserId = message.SendUserId,
                    ReceiveUserId = message.ReceiveUserId
                };

                repository.Add(messageEntity);
                unitOfWork.Commit();

                message.Id = messageEntity.Id;
                
                return new ReturnObjectDTO() { data = message, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }


        public ReturnObjectDTO UpdateMessageAsLooked(int id)
        {

            var entity = repository.GetById(id);// GetMessage(id);
            if (entity == null)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ. Güncellenecek Kayıt Bilgisi Bulunamadı.(2)" };
            }

            entity.IsLooked = true; 
 
            try
            {
                repository.Update(entity);
                unitOfWork.Commit();
           
                return new ReturnObjectDTO() { data = id, successMessage = "İşlem Başarılı" };
            }
            catch (Exception)
            {
                return new ReturnObjectDTO() { isSuccess = false, errorMessage = "İşlem BAŞARISIZ." };
            }
        }



    }
}
