using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALMissionSkill
    {
        private readonly AppDbContext _context;

        public DALMissionSkill(AppDbContext context)
        {
            _context = context;
        }

        public List<MissionSkill> GetMissionSkills()
        {
            try
            {
                var missionSkills = _context.MissionSkill.ToList();
                return missionSkills;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MissionSkill> GetMissionSkillById(int missionSkillId)
        {
            try
            {
                var missionSkills = _context.MissionSkill.Where(x=>x.Id==missionSkillId).ToList();
                return missionSkills;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> UpdateMissionSkill(int skillId, MissionSkill skill)
        {
            var result = string.Empty;
            if (skill == null)
            {
                result = "Null Object";
            }

            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {

                    var skillExist = _context.MissionSkill.Find(skillId);

                    if (skillExist == null)
                    {
                        await transaction.RollbackAsync();
                        result = "Mission Skill not found";
                    }
                    else
                    {
                        skillExist.SkillName = (skill.SkillName == null) ? skillExist.SkillName : skill.SkillName;
                        skillExist.Status = (skill.Status == null) ? skillExist.Status : skill.Status;
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Mission Skill Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                
                result = ex.Message;
            }
            return result;
        }
        public async Task<string> DeleteMissionSkill(int missionSkillId)
        {
            var result = string.Empty;
            try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {
                    var skillExist = await _context.MissionSkill.FindAsync(missionSkillId);
                    if(skillExist != null)
                    {
                        _context.MissionSkill.Remove(skillExist);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted SuccessFully";
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        result = "Mission skill not found";
                    }
                }
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public string AddMissionSkill(MissionSkill skill)
        {
            var result = "";
            try
            {
                
                    try
                    {
                        var newSkill = new MissionSkill
                        {

                            Status = skill.Status,
                            SkillName = skill.SkillName
                        };
                    
                        _context.MissionSkill.Add(newSkill);
                        _context.SaveChanges();
                       
                        result = "Mission Skill Added SuccessFully";

                    }
                    catch(Exception ex)
                    {
                        result = ex.Message;
                    }

                
            }
            catch(Exception ex)
            {
                result = ex.Message;
                
            }
            return result;
        }
    }
}
