using AutoMapper;
using API.Entities;
using API.ViewModels;


namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<CourseViewModel, Course>();
              CreateMap<StaffViewModel, Staff>();
            CreateMap<Course, CourseViewModel>()
           .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
           .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
           .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
           .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
           .ForMember(dest => dest.ModeOfEducation, opt => opt.MapFrom(src => src.ModeOfEducation))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.Tutor, opt => opt.MapFrom(src => src.Tutor));
           
               

           CreateMap<AddCourseViewModel, Course>()
           .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
           .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
           .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
           .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
           .ForMember(dest => dest.ModeOfEducation, opt => opt.MapFrom(src => src.ModeOfEducation))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.Tutor, opt => opt.MapFrom(src => src.Tutor));
         
            CreateMap<Staff, StaffViewModel>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
           .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
           
               

           CreateMap<AddStaffViewModel, Staff>()
           .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
           .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        
           
        }
        
        
    }
}