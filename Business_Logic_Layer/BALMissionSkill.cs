using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALMissionSkill
    {
        private readonly DALMissionSkill _dalMissionSkill;

        public BALMissionSkill(DALMissionSkill dalMissionSkill)
        {
            _dalMissionSkill = dalMissionSkill;
        }

        public List<MissionSkill> GetMissionSkills()
        {
            return _dalMissionSkill.GetMissionSkills();
        }

        public List<MissionSkill> GetMissionSkillById(int missionSkillId)
        {
            return _dalMissionSkill.GetMissionSkillById(missionSkillId);
        }

        public async Task<string> UpdateMissionSkill(int missionSkillId, MissionSkill missionSkill)
        {
            return await _dalMissionSkill.UpdateMissionSkill(missionSkillId, missionSkill);
        }

        public async Task<string> DeleteMissionSkill(int missionSkillId)
        {
            return await _dalMissionSkill.DeleteMissionSkill(missionSkillId);
        }

        public  string AddMissionSkill(MissionSkill missionSkill)
        {
            return _dalMissionSkill.AddMissionSkill(missionSkill);
        }
    }
}
