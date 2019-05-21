using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class ContactUsMessageLogic : BaseLogic
    {

        //Add new Message
        public ContactUsMessageModel AddMsg(ContactUsMessageModel contactusMsgModel)
        {
            ContactUsMessage msg = new ContactUsMessage
            {
                MessageDateTime = DateTime.Now,
                UserPhoneNumber = contactusMsgModel.phoneNum,
                UserEmail = contactusMsgModel.email,
                MessageText = contactusMsgModel.msgText
            };

            DB.ContactUsMessages.Add(msg);
            DB.SaveChanges();
            contactusMsgModel.id = msg.MessageID;
            return contactusMsgModel;
        }

    }
}
