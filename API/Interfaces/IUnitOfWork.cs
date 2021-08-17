using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository{get;}
        IStaffRepository StaffRepository{get;}
     
        Task<bool> Complete();
        bool HasChanges();
    }
}