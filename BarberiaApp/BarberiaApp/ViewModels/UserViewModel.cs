using BarberiaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }

        public UserRole MyUserRole { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyUserRole = new UserRole();
        }

        public async Task<bool> UserAccessValidation(string pEmail, string pPassword)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<User> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                User userDTO = new User();

                userDTO = await MyUser.GetUserInfo(pEmail);

                if (userDTO == null) return null;

                return userDTO;

            }
            catch
            (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<bool> AddUserAsync(string pEmail, string pPassword, string pName, string pBackUpEmail, string pPhone, string pAddress, int pUserRolID)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;
                MyUser.Name = pName;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.PhoneNumber = pPhone;
                MyUser.Address = pAddress;
                MyUser.UserRoleId = pUserRolID;


                bool R = await MyUser.AddUserAsync();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<bool> UpdateUser(User pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser = pUser;


                bool R = await MyUser.UpdateUserAsync();

                return R;

            }
            catch
            (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }

        public async Task<bool> UpdateUserPassword(User pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser = pUser;


                bool R = await MyUser.UpdateUserAsyncByPassword();

                return R;

            }
            catch
            (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }



    }
}
