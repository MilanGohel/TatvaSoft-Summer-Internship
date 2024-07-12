using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALCountry
    {
        private AppDbContext _context;

        public DALCountry(AppDbContext context)
        {
            _context = context;
        }

        public List<Countries> GetCountries()
        {
            try
            {
                var countryList = _context.Countries.ToList();
                return countryList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Countries> GetCountryById(int id)
        {
            try
            {
                var result = _context.Countries.Where(x => x.Id == id).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddCountry(Countries country)
        {
            var result = "";
            try
            {
                var countryExist = _context.Countries.Where(x => x.CountryName == country.CountryName).FirstOrDefault();

                if (countryExist == null)
                {
                    var newCountry = new Countries
                    {
                        CountryName = country.CountryName
                    };
                    _context.Countries.Add(newCountry);
                    _context.SaveChanges();
                    result = "Country Added Successfully";
                }
                else
                {
                    result = "Country Already Exists!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> DeleteCountry(int countryId)
        {
            var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var countryFound = await _context.Countries.FirstOrDefaultAsync(x => x.Id == countryId);
                        if (countryFound != null)
                        {
                            _context.Countries.Remove(countryFound);
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "Country Deleted Successfully";
                        }
                        else
                        {
                            result = "Country Not Found";
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

        public async Task<string> UpdateCountry(int countryId, Countries country)
        {
            try
            {
                var result = string.Empty;
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (country == null)
                        {
                            result = "Should Contain at least one update.";
                            return result;
                        }
                        var countryDetail = await _context.Countries.FindAsync(countryId);

                        if (countryDetail != null)
                        {
                            countryDetail.CountryName = country.CountryName ?? countryDetail.CountryName;

                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            result = "Country Updated Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "Country Not Found";
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
