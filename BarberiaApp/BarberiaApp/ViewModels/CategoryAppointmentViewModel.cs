using BarberiaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaApp.ViewModels
{
    public class CategoryAppointmentViewModel : BaseViewModel
    {
        public CategoryAppoinment MyCategory { get; set; }


        public CategoryAppointmentViewModel() { MyCategory = new CategoryAppoinment(); }


        public async Task<bool> AddCategory(string pDescription)
        {
            if(IsBusy) return false;
            IsBusy = true;

            try 
            {
                MyCategory.Description = pDescription;


                bool r = await MyCategory.AddCategoryAsync();

                return r;

            }
            catch(Exception) { throw; } finally { IsBusy = false; }


        }

        public async Task<ObservableCollection<CategoryAppoinment>> GetCategoriesAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                ObservableCollection<CategoryAppoinment> categories = new ObservableCollection<CategoryAppoinment>();


                categories = await MyCategory.GetAllCategories();


                if (categories == null) { return null; }
                return categories;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> UpdateCategory(CategoryAppoinment pCategory)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyCategory = pCategory;


                bool R = await MyCategory.UpdateCategoryAsync();

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
