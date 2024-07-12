using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALMissionApplication
    {
        private readonly DALMissionApplication _dalMissionApplication;

        public BALMissionApplication(DALMissionApplication dalMissionApplication)
        {
            _dalMissionApplication = dalMissionApplication;
        }

        public List<MissionApplication> GetMissionApplications()
        {
            return _dalMissionApplication.GetMissionApplicationList();
        }

        public async Task<string> AddMissionApplication(MissionApplication application)
        {
            return await _dalMissionApplication.AddMissionApplication(application);
        }

        public async Task<string> UpdateMissionApplication(int applicationId, MissionApplication application)
        {
            return await _dalMissionApplication.UpdateMissionApplication(applicationId, application);
        }

        public async Task<string> DeleteMissionApplication(int applicationId)
        {
            return await _dalMissionApplication.DeleteMissionApplication(applicationId);
        }
    }
}
