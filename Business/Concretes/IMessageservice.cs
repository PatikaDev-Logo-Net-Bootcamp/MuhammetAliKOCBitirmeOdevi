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

        public ReturnObjectDTO GetMessages(string user1, string user2)
        {
            var messages = Messages().Where(x=>(x.SendUserId == user1 && x.ReceiveUserId==user2) || (x.SendUserId == user2 && x.ReceiveUserId == user1) )
                .Select(x => new MessageDTO()
                {
                    Id = x.Id,
                    Text = x.Text,
                    DateCreated = x.DateCreated,
                    IsLooked = x.IsLooked,
                    SendUserId = x.SendUserId,
                    ReceiveUserId = x.ReceiveUserId

                }).OrderBy(x=>x.Id).ToList(); 

            return new ReturnObjectDTO() { data = messages, successMessage = "İşlem Başarılı" };
        }

        public ReturnObjectDTO GetMessagesWithConditions(string currentUserId, string receiverUserId, int id)
        {
            var messages = Messages().Where(x => x.SendUserId == receiverUserId && x.ReceiveUserId == currentUserId && x.Id>id)
                .Select(x => new MessageDTO()
                {
                    Id = x.Id,
                    Text = x.Text,
                    DateCreated = x.DateCreated,
                    IsLooked = x.IsLooked,
                    SendUserId = x.SendUserId,
                    ReceiveUserId = x.ReceiveUserId

                }).OrderBy(x => x.Id).ToList();

            return new ReturnObjectDTO() { data = messages, successMessage = "İşlem Başarılı" };
        }

        public ReturnObjectDTO GetUnLookedMessageCountForUser(string currentUserId)
        {
            var count = Messages().Where(x => x.ReceiveUserId == currentUserId && x.IsLooked == false).Count();

            return new ReturnObjectDTO() { data = count, successMessage = "İşlem Başarılı" };
        }


        public ReturnObjectDTO AddMessage(MessageDTO message)
        {
            try
            { 
                var messageEntity = new Message()
                {
                    Text = message.Text,
                    DateCreated = message.DateCreated,
                    IsLooked = message.IsLooked,
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
