using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALAdminMissionTheme
    {
        private readonly DALAdminMissionTheme _dALAdminMissionTheme;
        public BALAdminMissionTheme(DALAdminMissionTheme dALAdminMissionTheme)
        {
            _dALAdminMissionTheme = dALAdminMissionTheme;
        }
        public List<MissionTheme> GetMissionThemes()
        {
            return _dALAdminMissionTheme.GetMissionThemes();
        }
        public string AddMissionTheme(MissionTheme theme)
        {
            return _dALAdminMissionTheme.AddMissionTheme(theme);
        }
            
        public async Task<string> UpdateMissionTheme(int missionThemeId, MissionTheme theme)
        {
            return await _dALAdminMissionTheme.UpdateMissionTheme(missionThemeId, theme);
        }

        public async Task<string> DeleteMissionTheme(int missionThemeId)
        {
            return await _dALAdminMissionTheme.DeleteMissionTheme(missionThemeId); 
        }

        public List<MissionTheme> GetMissionThemeById(int id)
        {
            return _dALAdminMissionTheme.GetMissionThemeById(id);
        }
    }
}
