using System.Collections.Generic;
using System.Threading.Tasks;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IStaffRepository
    {
        void Add(AddStaffViewModel staff);
    Task<IEnumerable<StaffViewModel>> GetStaffsAsync();
     Task<StaffViewModel> GetStaffByNameAsync(string name);
      Task<IEnumerable<StaffViewModel>> GetStaffBySubjectAsync(string subject);
      
     Task<StaffViewModel> GetStaffByUserNameAsync(string username);
     Task<StaffViewModel> GetStaffByIdAsync(int id);
      void Delete(StaffViewModel staff);
    void Update(StaffViewModel staff);
    }
}