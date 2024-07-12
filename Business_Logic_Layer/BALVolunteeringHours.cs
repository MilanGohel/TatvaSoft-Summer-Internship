using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALVolunteeringHours
    {
        private readonly DALVolunteeringHours _dalVolunteeringHours;

        public BALVolunteeringHours(DALVolunteeringHours dalVolunteeringHours)
        {
            _dalVolunteeringHours = dalVolunteeringHours;
        }

        public async Task<string> AddVolunteeringHours(VolunteeringHours hours)
        {
            return await _dalVolunteeringHours.AddVolunteeringHours(hours);
        }

        public List<VolunteeringHours> GetVolunteeringHoursList()
        {
            return _dalVolunteeringHours.GetVolunteeringHoursList();
        }

        public async Task<string> UpdateVolunteeringHours(int id, VolunteeringHours hours)
        {
            return await _dalVolunteeringHours.UpdateVolunteeringHours(id, hours);
        }

        public async Task<string> DeleteVolunteeringHours(int id)
        {
            return await _dalVolunteeringHours.DeleteVolunteeringHours(id);
        }
    }
}
