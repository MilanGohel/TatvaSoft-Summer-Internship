using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALCity
    {
        private AppDbContext _context;

        public DALCity(AppDbContext context)
        {
            _context = context;
        }

        public List<Cities> GetCities()
        {
            try
            {
                var cityList = _context.Cities.ToList();
                return cityList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cities> GetCityByCountryId(int id)
        {
            try
            {
                var result = _context.Cities.Where(x => x.CountryId == id).ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AddCity(Cities city)
        {
            var result = "";
            try
            {
                var cityExist = _context.Cities.Where(x => x.CityName == city.CityName && x.CountryId == city.CountryId).FirstOrDefault();

                if (cityExist == null)
                {
                    var newCity = new Cities
                    {
                        CityName = city.CityName,
                        CountryId = city.CountryId
                    };
                    _context.Cities.Add(newCity);
                    _context.SaveChanges();
                    result = "City Added Successfully";
                }
                else
                {
                    result = "City Already Exists!";
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public async Task<string> DeleteCity(int cityId)
        {
            var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var cityFound = await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
                        if (cityFound != null)
                        {
                            _context.Cities.Remove(cityFound);
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            result = "City Deleted Successfully";
                        }
                        else
                        {
                            result = "City Not Found";
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

        public async Task<string> UpdateCity(int cityId, Cities city)
        {
            try
            {
                var result = string.Empty;
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (city == null)
                        {
                            result = "Should Contain at least one update.";
                            return result;
                        }
                        var cityDetail = await _context.Cities.FindAsync(cityId);

                        if (cityDetail != null)
                        {
                            cityDetail.CityName = city.CityName ?? cityDetail.CityName;
                            cityDetail.CountryId = city.CountryId != 0 ? city.CountryId : cityDetail.CountryId;

                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            result = "City Updated Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "City Not Found";
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
