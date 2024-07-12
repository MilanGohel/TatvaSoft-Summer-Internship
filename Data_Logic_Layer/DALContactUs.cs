using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALContactUs
    {
        private readonly AppDbContext _context;
        public DALContactUs(AppDbContext context)
        {
            _context = context;
        }   

        public string AddContactUs(ContactUs contactus)
        {
            string result = string.Empty;
            try
            {
                var newContactUs = new ContactUs
                {
                    UserId = contactus.UserId,
                    Name = contactus.Name,
                    CreatedDate = DateTime.Now,
                    EmailAddress = contactus.EmailAddress,
                    Subject = contactus.Subject,
                    Message = contactus.Message,
                };
                _context.ContactUs.Add(newContactUs);
                result = "New contact Added Success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
