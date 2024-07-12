using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALMissionApplication
    {
        private readonly AppDbContext _context;
        public DALMissionApplication(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddMissionApplication(MissionApplication application)
        {
            string result = "";
            try
            {
                
                    try
                    {
                        var applicationExist = from ma in _context.MissionApplication
                                               where ma.UserId == application.UserId &&
                                               ma.MissionId == application.MissionId
                                               select ma;
                        if (applicationExist.Any())
                        {
                           
                            result = "Application Already Exists";
                        }
                        else
                        {
                            var newApplication = new MissionApplication
                            {
                                AppliedDate = DateTime.UtcNow,
                                UserId = application.UserId,
                                MissionId = application.MissionId,
                                Sheet = application.Sheet,
                                Status = false,
                              
                            };
                            await _context.MissionApplication.AddAsync(newApplication);
                            await _context.SaveChangesAsync();
                           
                            result = "Mission Application Added Successfully";
                        }
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
        public List<MissionApplication> GetMissionApplicationList()
        {
            try
            {
                var applications = _context.MissionApplication.ToList();
                return applications;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteMissionApplication(int applicationId)
        {
            var result = string.Empty;
            using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var applicationExists = await _context.MissionApplication.FindAsync(applicationId);
                    if (applicationExists != null)
                    {
                        _context.MissionApplication.Remove(applicationExists);
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

        public async Task<string> UpdateMissionApplication(int applicationId, MissionApplication application)
        {
            var result = string.Empty;
            if(application == null)
            {
                result = "Null Object";
                return result;
            }
            try
            {
                using(var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var applicationExists = await _context.MissionApplication.FindAsync(applicationId);
                        if (applicationExists != null)
                        {
                            applicationExists.Sheet = (application.Sheet == null) ? applicationExists.Sheet : application.Sheet;
                            applicationExists.Status = application.Status == null ? applicationExists.Status : application.Status;
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "Updated Successfully";
                            return result;
                        }
                        else
                        {
                            result = "Application Not Found";
                        }
                    }
                    catch(Exception ex)
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
