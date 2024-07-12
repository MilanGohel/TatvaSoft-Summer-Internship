using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALVolunteeringHours
    {
        private readonly AppDbContext _context;

        public DALVolunteeringHours(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddVolunteeringHours(VolunteeringHours hours)
        {
            string result = "";
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var userExists = await _context.User.AnyAsync(u => u.Id == hours.UserId);
                        var missionExists = await _context.Mission.AnyAsync(m => m.Id == hours.MissionId);

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

                        var newVolunteeringHours = new VolunteeringHours
                        {
                            UserId = hours.UserId,
                            MissionId = hours.MissionId,
                            MissionName = hours.MissionName,
                            DateVolunteered = hours.DateVolunteered,
                            Hours = hours.Hours,
                            Minutes = hours.Minutes,
                            Message = hours.Message
                        };

                        await _context.VolunteeringHours.AddAsync(newVolunteeringHours);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Volunteering Hours Added Successfully";
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

        public List<VolunteeringHours> GetVolunteeringHoursList()
        {
            try
            {
                var hoursList = _context.VolunteeringHours.Include(v => v.User).Include(v => v.Mission).ToList();
                return hoursList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateVolunteeringHours(int id, VolunteeringHours hours)
        {
            string result = "";
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    var existingHours = await _context.VolunteeringHours.FindAsync(id);
                    if (existingHours == null)
                    {
                        await transaction.RollbackAsync();
                        return "Volunteering Hours not found";
                    }

                    var userExists = await _context.User.AnyAsync(u => u.Id == hours.UserId);
                    var missionExists = await _context.Mission.AnyAsync(m => m.Id == hours.MissionId);

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

                    existingHours.UserId = hours.UserId;
                    existingHours.MissionId = hours.MissionId;
                    existingHours.MissionName = hours.MissionName;
                    existingHours.DateVolunteered = hours.DateVolunteered;
                    existingHours.Hours = hours.Hours;
                    existingHours.Minutes = hours.Minutes;
                    existingHours.Message = hours.Message;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = "Volunteering Hours Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> DeleteVolunteeringHours(int id)
        {
            string result = "";
            try
            {
                var existingHours = await _context.VolunteeringHours.FindAsync(id);
                if (existingHours == null)
                {
                    return "Volunteering Hours not found";
                }

                _context.VolunteeringHours.Remove(existingHours);
                await _context.SaveChangesAsync();
                result = "Volunteering Hours Deleted Successfully";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
