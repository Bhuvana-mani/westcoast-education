
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
  [ApiController]
  [Route("api/courses")]
  public class CoursesController : ControllerBase
    { 
      private readonly IUnitOfWork _unitOfWork;

    public CoursesController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourses()
    {
      return Ok(await _unitOfWork.CourseRepository.GetCoursesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseViewModel>> GetCourseById(int id)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByIdAsync(id));
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult<CourseViewModel>> FindByCourse(string code)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByCourseCodeAsync(code));
    }
    [HttpGet("staff/{tutor}")]
    public async Task<ActionResult<CourseViewModel>> FindByTutor(string tutor)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByTutorAsync(tutor));
    }
     [HttpGet("lang/{language}")]
    public async Task<ActionResult<CourseViewModel>> FindByLanguage(string language)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByLanguageAsync(language));
    }
     [HttpGet("status/{status}")]
    public async Task<ActionResult<CourseViewModel>> FindByStatus(string status)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByStatusAsync(status));
    }
     [HttpGet("mode/{mode}")]
    public async Task<ActionResult<CourseViewModel>> FindByModeOfEducation(string mode)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByModeAsync(mode));
    }
      [HttpGet("name/{name}")]
    public async Task<ActionResult<CourseViewModel>> FindByCourseName(string name)
    {
      return Ok(await _unitOfWork.CourseRepository.GetCourseByNameAsync(name));
    }
    [HttpPost()]
    public async Task<ActionResult> AddCourse(AddCourseViewModel model)
    {

       _unitOfWork.CourseRepository.Add(model);
      
      if (await _unitOfWork.Complete())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Could not save the course");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>Delete(int id)
    {
      var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);

      if (course == null) return NotFound($"Could not find the course with id: {id}");

      _unitOfWork.CourseRepository.Delete(course);
      
      if (await _unitOfWork.Complete()) return NoContent();

      return StatusCode(500, "The course couldn't be deleted");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
    {
      var course = await _unitOfWork.CourseRepository.GetCourseByIdAsync(id);

      course.ModeOfEducation=model.ModeOfEducation;
       course.Language=model.Language;
        course.Duration=model.Duration;
        course.Status=model.Status;
        course.Tutor=model.Tutor;

      _unitOfWork.CourseRepository.Update(course);
      
      if (await _unitOfWork.Complete()) return NoContent();

      return StatusCode(500, "Oops! Something went wrong, not able to update");
    }
       
    }
}