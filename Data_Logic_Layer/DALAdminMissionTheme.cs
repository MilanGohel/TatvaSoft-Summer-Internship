using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALAdminMissionTheme
    {
        private AppDbContext _context;
        public DALAdminMissionTheme(AppDbContext context)
        {
            _context = context;
        }

        public List<MissionTheme> GetMissionThemes()
        {
            try
            {
                var themeList = _context.MissionTheme.ToList();
                return themeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<MissionTheme> GetMissionThemeById(int id)
        {
            try
            {
                var result = _context.MissionTheme.Where(x => x.Id == id).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public string AddMissionTheme(MissionTheme theme)
        {
            var result = "";
            try
            {
               var themeExist = _context.MissionTheme.Where(x => x.ThemeName == theme.ThemeName).FirstOrDefault();

                if (themeExist == null)
                {
                    var newTheme = new MissionTheme
                    {
                        ThemeName = theme.ThemeName,
                        Status = theme.Status
                    };
                    _context.MissionTheme.Add(newTheme);
                    _context.SaveChanges();
                    result = "Theme Added Successfully";
                }
                else
                {
                    result = "Theme Already Exists!";
                    return result;


                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;

        }

        public async Task<string> DeleteMissionTheme(int missionThemeId)
        {
            var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var themeFound = await _context.MissionTheme.FirstOrDefaultAsync(x => x.Id == missionThemeId);
                        if (themeFound != null)
                        {
                            _context.MissionTheme.Remove(themeFound);
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "Mission Theme Deleted Successfully";
                        }
                        else
                        {
                            result = "Mission Theme Not Found";
                        }

                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<string> UpdateMissionTheme(int missionThemeId, MissionTheme theme)
        {
            try
            {
                var result = string.Empty;
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if(theme == null)
                        {
                            result = "Should Contain atleast one updation.";
                            return result;
                        }
                        var themeDetail = await _context.MissionTheme.FindAsync(missionThemeId);
                        
                        if (themeDetail != null)
                        {
                            themeDetail.ThemeName = (theme.ThemeName == null) ? themeDetail.ThemeName : theme.ThemeName;
                            themeDetail.Status = (theme.Status == null) ? themeDetail.Status : theme.Status;
                      
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            result = "Mission Theme Updated Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "Mission Theme Not Found";
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
