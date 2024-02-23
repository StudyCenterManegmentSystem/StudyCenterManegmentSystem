﻿using Application.Dtos.StudentDtos;

namespace Web.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        private readonly IStudentService _studentService = studentService;

        [HttpPost("create-student")]
        public async Task<IActionResult> AddStudentAsync(AddStudentDto dto)
        {
            try
            {
                var result = await _studentService.AddStudentAsync(dto);
                return Ok(result);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("update-student")]
        public async Task<IActionResult> UpdateStudentAsync(UpdateStudentDto dto)
        {
            try
            {
                var result = await _studentService.UpdateStudentAsync(dto);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("delete-student/{id}")]
        public async Task<IActionResult> DeleteStudentAsync(string id)
        {
            try
            {
                 await _studentService.DeleteStudentAsync(id);
                return Ok("Student mofaqiyatli o'chirildi");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CustomException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}