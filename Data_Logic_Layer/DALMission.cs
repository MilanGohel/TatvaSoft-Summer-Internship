using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALMission
    {
        private readonly AppDbContext _context;
        public DALMission(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddMission(Mission mission)
        {
            string result = "";
            try
            {
                
                    try
                    {


                        var newMission = new Mission
                        {
                            CountryId = mission.CountryId,
                            CityId = mission.CityId,
                            StartDate = mission.StartDate,
                            EndDate = mission.EndDate,
                            RegistrationDeadLine = mission.RegistrationDeadLine,
                            MissionThemeId = mission.MissionThemeId,
                            MissionSkillId = mission.MissionSkillId,
                            MissionImages = mission.MissionImages,
                            MissionDocuments = mission.MissionDocuments,
                            MissionDescription = mission.MissionDescription,
                            MissionType = mission.MissionType,
                            MissionTitle = mission.MissionTitle,
                            MissionVideoUrl = mission.MissionVideoUrl,
                            MissionAvailability = mission.MissionAvailability,
                            TotalSheets = mission.TotalSheets
                        };
                            await _context.Mission.AddAsync(newMission);
                            await _context.SaveChangesAsync();
                            
                            result = "Mission Added Successfully";
                        
                    }
                    catch (Exception ex)
                    {
                        
                        result = ex.Message;
                    }
                
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public List<Mission> GetMissionList()
        {
            try
            {
                var missions = _context.Mission.Where(x => !x.IsDeleted).ToList();
                return missions;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Mission> GetMissionById(int id)
        {
            try
            {
                var mission = _context.Mission.Where(x => !x.IsDeleted && x.Id == id).ToList();
                return mission;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteMission(int missionId)
        {
            var result = string.Empty;
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var missionExists = await _context.Mission.FindAsync(missionId);
                    if (missionExists != null)
                    {
                        missionExists.IsDeleted = true;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Mission Deleted Successfully";
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        result = "Mission Doesn't Exists";
                    }

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    result = ex.Message;
                }

            }
            return result;
        }

        public async Task<string> UpdateMission(int missionId, Mission mission)
        {
            var result = string.Empty;
            if (mission == null)
            {
                result = "Null Object";
                return result;
            }
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var missionExists = await _context.Mission.FindAsync(missionId);
                        if (missionExists != null)
                        {
                            missionExists.TotalSheets = (mission.TotalSheets == null) ? missionExists.TotalSheets : mission.TotalSheets;
                            missionExists.MissionType = (mission.MissionType == null) ? missionExists.MissionType : mission.MissionType;
                            missionExists.StartDate = (mission.StartDate == null) ? missionExists.StartDate : mission.StartDate;
                            missionExists.EndDate = (mission.EndDate == null) ? missionExists.EndDate : mission.EndDate;
                            missionExists.RegistrationDeadLine = (mission.RegistrationDeadLine == null) ? missionExists.RegistrationDeadLine : mission.RegistrationDeadLine;
                            missionExists.MissionImages = (mission.MissionImages == null) ? missionExists.MissionImages : mission.MissionImages;
                            missionExists.MissionDocuments = (mission.MissionDocuments == null) ? missionExists.MissionDocuments : mission.MissionDocuments;
                            missionExists.MissionDescription = (mission.MissionDescription == null) ? missionExists.MissionDescription : mission.MissionDescription;
                            missionExists.MissionType = (mission.MissionType == null) ? missionExists.MissionType : mission.MissionType;
                            missionExists.MissionTitle = (mission.MissionTitle == null) ? missionExists.MissionTitle : mission.MissionTitle;
                            missionExists.MissionVideoUrl = (mission.MissionVideoUrl == null) ? missionExists.MissionVideoUrl : mission.MissionVideoUrl;
                            missionExists.MissionAvailability = (mission.MissionAvailability == null) ? missionExists.MissionAvailability : mission.MissionAvailability;
                            missionExists.TotalSheets = (mission.TotalSheets == null) ? missionExists.TotalSheets : mission.TotalSheets;
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "Mission Updated";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "Mission Already Exists";
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        result = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
