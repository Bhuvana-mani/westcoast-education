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
     [Route("api/staffs")]
    public class StaffController : ControllerBase
    {
         private readonly IUnitOfWork _unitOfWork;

    public StaffController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<StaffViewModel>>> GetStaffs()
    {
      return Ok(await _unitOfWork.StaffRepository.GetStaffsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StaffViewModel>> GetStaffById(int id)
    {
      return Ok(await _unitOfWork.StaffRepository.GetStaffByIdAsync(id));
    }

    [HttpGet("staffname/{name}")]
    public async Task<ActionResult<StaffViewModel>> FindByName(string name)
    {
      return Ok(await _unitOfWork.StaffRepository.GetStaffByNameAsync(name));
    }
    [HttpGet("subject/{subject}")]
    public async Task<ActionResult<StaffViewModel>> FindBySubject(string subject)
    {
      return Ok(await _unitOfWork.StaffRepository.GetStaffBySubjectAsync(subject));
    }
    
    [HttpPost()]
    public async Task<ActionResult> AddTeacher(AddStaffViewModel model)
    {

       _unitOfWork.StaffRepository.Add(model);
      
      if (await _unitOfWork.Complete())
      {
        return StatusCode(201);
      }

      return StatusCode(500, "Could not save the staff");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>Delete(int id)
    {
      var staff = await _unitOfWork.StaffRepository.GetStaffByIdAsync(id);

      if (staff == null) return NotFound($"Could not find the staff with id: {id}");

      _unitOfWork.StaffRepository.Delete(staff);
      
      if (await _unitOfWork.Complete()) return NoContent();

      return StatusCode(500, "The staff couldn't be deleted");
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateStaff(int id, UpdateStaffViewModel model)
    {
      var staff = await _unitOfWork.StaffRepository.GetStaffByIdAsync(id);

      staff.Address=model.Address;
       staff.Email=model.Email;
        staff.Phone=model.Phone;
        
      _unitOfWork.StaffRepository.Update(staff);
      
      if (await _unitOfWork.Complete()) return NoContent();

      return StatusCode(500, "Oops! Something went wrong, not able to update");
    }
       
        
    }
}