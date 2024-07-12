using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALVolunteeringGoals
    {
        private readonly AppDbContext _context;

        public DALVolunteeringGoals(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddVolunteeringGoals(VolunteeringGoals goals)
        {
            string result = "";
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        //var userExists = await _context.User.FindAsync(goals.UserId);
                        //var missionExists = await _context.Mission.FindAsync(goals.MissionId);

                        //if (userExists != null)
                        //{
                        //    await transaction.RollbackAsync();
                        //    return "User does not exist";
                        //}

                        //if (missionExists != null)
                        //{
                        //    await transaction.RollbackAsync();
                        //    return "Mission does not exist";
                        //}

                        var newVolunteeringGoals = new VolunteeringGoals
                        {
                            UserId = goals.UserId,
                            MissionId = goals.MissionId,
                            MissionName = goals.MissionName,
                            Date = goals.Date,
                            Action = goals.Action,
                            Message = goals.Message
                        };

                        await _context.VolunteeringGoals.AddAsync(newVolunteeringGoals);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Volunteering Goals Added Successfully";
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

        public List<VolunteeringGoals> GetVolunteeringGoalsList()
        {
            try
            {
                var goalsList = _context.VolunteeringGoals.Include(v => v.User).Include(v => v.Mission).ToList();
                return goalsList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateVolunteeringGoals(int id, VolunteeringGoals goals)
        {
            string result = "";
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var existingGoals = await _context.VolunteeringGoals.FindAsync(id);
                    if (existingGoals == null)
                    {
                        await transaction.RollbackAsync();
                        return "Volunteering Goals not found";
                    }

                    var userExists = await _context.User.AnyAsync(u => u.Id == goals.UserId);
                    var missionExists = await _context.Mission.AnyAsync(m => m.Id == goals.MissionId);

                    if (!userExists)
                    {
                        await transaction.RollbackAsync();
                        return "User does not exist";
                    }

                    if (!missionExists)
                    {
                        await transaction.RollbackAsync();
                        return "Mission does not exist";
                    }

                    existingGoals.UserId = goals.UserId;
                    existingGoals.MissionId = goals.MissionId;
                    existingGoals.MissionName = goals.MissionName;
                    existingGoals.Date = goals.Date;
                    existingGoals.Action = goals.Action;
                    existingGoals.Message = goals.Message;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = "Volunteering Goals Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> DeleteVolunteeringGoals(int id)
        {
            string result = "";
            try
            {
                var existingGoals = await _context.VolunteeringGoals.FindAsync(id);
                if (existingGoals == null)
                {
                    return "Volunteering Goals not found";
                }

                _context.VolunteeringGoals.Remove(existingGoals);
                await _context.SaveChangesAsync();
                result = "Volunteering Goals Deleted Successfully";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
