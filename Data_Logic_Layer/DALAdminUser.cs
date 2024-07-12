using Data_Logic_Layer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer
{
    public class DALAdminUser
    {
        private readonly AppDbContext _context;

        public DALAdminUser(AppDbContext context)
        {
            _context = context;
        }

        public string AddUser(User user)
        {
            var result = "";
            try
            {
                var userEmailExists = _context.User.FirstOrDefault(x => !x.IsDeleted && x.EmailAddress == user.EmailAddress);
                if (userEmailExists == null)
                {
                    var newUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        EmailAddress = user.EmailAddress,
                        Password = user.Password,
                        UserType = user.UserType,
                        CreatedDate = DateTime.UtcNow,
                        IsDeleted = false,
                    };
                    _context.User.Add(newUser);
                    _context.SaveChanges();
                    var maxEmployeeId = 0;
                    var lastUserDetail = _context.UserDetail.ToList().LastOrDefault();

                    if (lastUserDetail != null)
                    {
                        maxEmployeeId = Convert.ToInt32(lastUserDetail.EmployeeId);
                    }
                    int newEmployeeId = maxEmployeeId + 1;
                    var newUserDetail = new UserDetail
                    {
                        UserId = newUser.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        EmailAddress = user.EmailAddress,
                        UserType = user.UserType,
                        Name = user.FirstName,
                        Surname = user.LastName,
                        EmployeeId = newEmployeeId.ToString(),
                        Department = "IT",
                        Status = true
                    };
                    _context.UserDetail.Add(newUserDetail);
                    _context.SaveChanges();

                    result = "User Add Suceessfully.";
                }
                else
                {
                    result = "Email is already exists.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        
        public List<UserDetail> GetUserList()
        {
            var userDetailList = from u in _context.User
                                 join ud in _context.UserDetail on u.Id equals ud.UserId into userDetailGroup
                                 from userDetail in userDetailGroup.DefaultIfEmpty()
                                 where !u.IsDeleted && u.UserType == "user" && !userDetail.IsDeleted
                                 select new UserDetail
                                 {
                                     Id = u.Id,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     PhoneNumber = u.PhoneNumber,
                                     EmployeeId = userDetail.EmployeeId,
                                     Department = userDetail.Department,
                                     Status = userDetail.Status,
                                 };
            return userDetailList.ToList();
        }

        public async Task<string> DeleteUser(int userId)
        {
             var result = string.Empty;
            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var userDetail = await _context.UserDetail.FirstOrDefaultAsync(x => x.UserId == userId);
                        if (userDetail != null)
                        {
                            userDetail.IsDeleted = true;
                        }
                        else
                        {
                            result = "User Not Found";
                            return result;
                        }
                        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
                        if (user != null)
                        {
                            user.IsDeleted = true;

                        }
                        else
                        {
                            result = "User Not Found";
                        }

                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        result = "Delete user successfully";
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }

                }
                return result;
            }
            catch(Exception)
            {
                throw;
            }

        }
        //public List<User> GetUserById(int userId)
        //{
        //    try
        //    {
        //        var user = _context.User.Find(userId);
        //        return 
        //    }
        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<string> UpdateUser(int userId, UserDetail user)
        {
            try
            {
                var result = string.Empty;
                if(user == null)
                {
                    result = "Should Contain Atlease One Updation";
                    return result;
                }
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var userDetail = await _context.User.FindAsync(userId);
                        var userDetailData = await _context.UserDetail.FirstOrDefaultAsync(x => x.UserId == userId);
                        if (userDetail != null)
                        {
                            userDetail.FirstName = (user.FirstName == null) ? userDetail.FirstName : user.FirstName;
                            userDetail.LastName = (user.LastName == null) ? userDetail.LastName : user.LastName;
                            userDetail.PhoneNumber = (user.PhoneNumber == null) ? userDetail.PhoneNumber : user.PhoneNumber;
                            userDetailData.Name = (user.FirstName == null) ? userDetailData.Name : user.FirstName;
                            userDetailData.Surname = (user.LastName == null) ? userDetailData.Surname : user.LastName;
                            userDetailData.PhoneNumber = (user.PhoneNumber == null) ? userDetailData.PhoneNumber : user.PhoneNumber;
                            userDetailData.UserImage = (user.UserImage == null) ? userDetailData.LastName : user.UserImage;  
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();

                            result = "User Updated Successfully";
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            result = "User Not Found";
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
