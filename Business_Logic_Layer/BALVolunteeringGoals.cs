using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALVolunteeringGoals
    {
        private readonly DALVolunteeringGoals _dalVolunteeringGoals;

        public BALVolunteeringGoals(DALVolunteeringGoals dalVolunteeringGoals)
        {
            _dalVolunteeringGoals = dalVolunteeringGoals;
        }

        public async Task<string> AddVolunteeringGoals(VolunteeringGoals goals)
        {
            return await _dalVolunteeringGoals.AddVolunteeringGoals(goals);
        }

        public List<VolunteeringGoals> GetVolunteeringGoalsList()
        {
            return _dalVolunteeringGoals.GetVolunteeringGoalsList();
        }

        public async Task<string> UpdateVolunteeringGoals(int id, VolunteeringGoals goals)
        {
            return await _dalVolunteeringGoals.UpdateVolunteeringGoals(id, goals);
        }

        public async Task<string> DeleteVolunteeringGoals(int id)
        {
            return await _dalVolunteeringGoals.DeleteVolunteeringGoals(id);
        }
    }
}
