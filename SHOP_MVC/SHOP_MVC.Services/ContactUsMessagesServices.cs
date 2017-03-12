using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP_MVC.DataLayer;

namespace SHOP_MVC.Services
{
    public class ContactUsMessagesServices
    {
        public List<ContactUsMessage> Get()
        {
            using (var db = new EntityContext())
            {
                var contactUsMessages = db.ContactUsMessages.ToList();
                return contactUsMessages;
            }
        }

        public void ReadByID(int id)
        {
            using (var db = new EntityContext())
            {
                var contactUsMessage = db.ContactUsMessages.Single(item => item.ID == id);
                contactUsMessage.IsRead = true;
                db.SaveChanges();
            }
        }

        public void UnReadByID(int id)
        {
            using (var db = new EntityContext())
            {
                var contactUsMessage = db.ContactUsMessages.Single(item => item.ID == id);
                contactUsMessage.IsRead = false;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new EntityContext())
            {
                var contactUsMessage = db.ContactUsMessages.Single(item => item.ID == id);
                db.ContactUsMessages.Remove(contactUsMessage);
                db.SaveChanges();
            }
        }

        
    }
}
