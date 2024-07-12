using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALMission
    {
        private readonly DALMission _dalMission;

        public BALMission(DALMission dalMission)
        {
            _dalMission = dalMission;
        }

        public List<Mission> GetMissions()
        {
            return _dalMission.GetMissionList();
        }

        public List<Mission> GetMissionById(int missionId)
        {
            return _dalMission.GetMissionById(missionId);
        }

        public async Task<string> AddMission(Mission mission)
        {
            return await _dalMission.AddMission(mission);
        }

        public async Task<string> UpdateMission(int missionId, Mission mission)
        {
            return await _dalMission.UpdateMission(missionId, mission);
        }

        public async Task<string> DeleteMission(int missionId)
        {
            return await _dalMission.DeleteMission(missionId);
        }
    }
}
