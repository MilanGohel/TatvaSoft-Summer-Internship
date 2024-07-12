using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALCMS
    {
        private readonly AppDbContext _context;

        public DALCMS(AppDbContext context)
        {
            _context = context;
        }

        public List<CMS> GetCMSList()
        {
            try
            {
                return _context.CMS.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CMS> GetCMSById(int id)
        {
            try
            {
                return _context.CMS.Where(x => x.Id == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> AddCMS(CMS cms)
        {
            var result = "";
            if (cms != null)
            {
                result = "null";
                return result;
            }
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var newCMS = new CMS
                        {
                            CreatedDate = DateTime.Now,
                            Description = cms.Description,
                            Status  = cms.Status,
                            Title = cms.Title
                        };
                        
                        await _context.CMS.AddAsync(newCMS);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "CMS Added Successfully";
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

        public async Task<string> UpdateCMS(int id, CMS cms)
        {
            var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var cmsExist = await _context.CMS.FindAsync(id);
                        if (cmsExist != null)
                        {
                            cmsExist.Title = cms.Title ?? cmsExist.Title;
                            cmsExist.Description = cms.Description ?? cmsExist.Description;
                            cmsExist.Status = cms.Status ?? cmsExist.Status;

                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "CMS Updated Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "CMS Not Found";
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

        public async Task<string> DeleteCMS(int id)
        {
            var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var cmsExist = await _context.CMS.FindAsync(id);
                        if (cmsExist != null)
                        {
                            _context.CMS.Remove(cmsExist);
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "CMS Deleted Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "CMS Not Found";
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
