using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALContactUs
    {
        DALContactUs _dalContactUs;
        public BALContactUs(DALContactUs dalContactUs)
        {
            _dalContactUs = dalContactUs;
        }

        public string AddContactUs(ContactUs contactUs)
        {
            return _dalContactUs.AddContactUs(contactUs);
        }
    }
}
