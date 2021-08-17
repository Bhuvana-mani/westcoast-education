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
    public class CourseRepository : ICourseRepository
    {   
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    public CourseRepository(DataContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public void Add(AddCourseViewModel course)
    {
      var courseToAdd = _mapper.Map<Course>(course, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(courseToAdd).State = EntityState.Added;
    }

    public void Delete(CourseViewModel course)
    {
       var courseToDelete = _mapper.Map<Course>(course, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(courseToDelete).State = EntityState.Deleted;
    }

    public async Task<CourseViewModel> GetCourseByIdAsync(int id)
    {
      return await _context.Courses
        .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
        .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CourseViewModel> GetCourseByCourseCodeAsync(string code)
    {
      return await _context.Courses
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.CourseCode.ToLower() == code.ToLower());
    }
     public async Task<IEnumerable<CourseViewModel>> GetCourseByTutorAsync(string tutor)
    {
      return await _context.Courses.Where(c => c.Tutor.ToLower() == tutor.ToLower())
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }
     public async Task<IEnumerable<CourseViewModel>> GetCourseByStatusAsync(string status)
    {
      return await _context.Courses.Where(c => c.Status.ToLower() == status.ToLower())
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
      
    }
     public async Task<IEnumerable<CourseViewModel>> GetCourseByModeAsync(string mode)
    {
      return await _context.Courses.Where(c => c.ModeOfEducation.ToLower() == mode.ToLower())
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }
     public async Task<IEnumerable<CourseViewModel>> GetCourseByLanguageAsync(string language)
    {
      return await _context.Courses.Where(c => c.Language.ToLower() == language.ToLower())
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .ToListAsync();
    }
     public async Task<CourseViewModel> GetCourseByNameAsync(string name)
    {
      return await _context.Courses
      .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync(c => c.CourseName.ToLower() == name.ToLower());
    }

    public async Task<IEnumerable<CourseViewModel>> GetCoursesAsync()
    {
      return await _context.Courses
        .ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public void Update(CourseViewModel course)
    {
      var courseToUpdate = _mapper.Map<Course>(course, opt =>
      {
        opt.Items["repo"] = _context;
      });
      _context.Entry(courseToUpdate).State = EntityState.Modified;
    }
        
    }
}