using BarberiaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaApp.ViewModels
{
    public class UserRoleViewModel : BaseViewModel
    {
        public UserRole MyUserRole { get; set; }
        public UserRoleViewModel() 
        {
            MyUserRole = new UserRole();
        }

        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            try
            {
                List<UserRole> roles = new List<UserRole>();
                roles = await MyUserRole.GetAllUserRoles();

                if (roles == null)
                {
                    return null;
                }

                return roles;
            }
            catch (Exception e)
            {
                string msg = e.Message;

                return null;

                throw;
            }
        }




    }
}
