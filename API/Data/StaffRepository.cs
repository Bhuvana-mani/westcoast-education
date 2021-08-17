using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StaffRepository : IStaffRepository
    {   
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    public StaffRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public void Add(AddStaffViewModel staff)
    {
      var staffToAdd = _mapper.Map<Staff>(staff, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(staffToAdd).State = EntityState.Added;
    }

    public void Delete(StaffViewModel staff)
    {
       var staffToDelete = _mapper.Map<Staff>(staff, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(staffToDelete).State = EntityState.Deleted;
    }

    public async Task<StaffViewModel> GetStaffByIdAsync(int id)
    {
      return await _context.Staffs
        .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
        .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<StaffViewModel> GetStaffByNameAsync(string name)
    {
      return await _context.Staffs
      .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.FirstName.ToLower() == name.ToLower());
    }
     public async Task<StaffViewModel> GetStaffByUserNameAsync(string name)
    {
      return await _context.Staffs
      .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.UserName.ToLower() == name.ToLower());
    }
     public async Task<IEnumerable<StaffViewModel>> GetStaffBySubjectAsync(string subject)
    {
      return await _context.Staffs.Where(c => c.Subject.ToLower() == subject.ToLower())
      .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }
   
    public async Task<IEnumerable<StaffViewModel>> GetStaffsAsync()
    {
      return await _context.Staffs
        .ProjectTo<StaffViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public void Update(StaffViewModel staff)
    {
      var staffToUpdate = _mapper.Map<Staff>(staff, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(staffToUpdate).State = EntityState.Modified;
    }
        
    }
}