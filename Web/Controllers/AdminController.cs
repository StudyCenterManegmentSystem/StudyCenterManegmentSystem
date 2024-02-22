﻿using Application.Dtos.TeacherDto;


namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController(IAdminService adminService) : ControllerBase
{
    private readonly IAdminService _adminService = adminService;

    [HttpPost("register-teacher")]
    public async Task<IActionResult> RegisterTeacher(TeacherRegisterRequest request)
    {
        try
        {
            var response = await _adminService.RegisterTeacherAsync(request);
            return response.Success ? Ok(response) : Conflict(response);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin(RegistrationRequest request)
    {
        try
        {
            var response = await _adminService.RegisterAdminAsync(request);
            return response.Success ? Ok(response) : Conflict(response);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpPost("register-superadmin")]
    public async Task<IActionResult> RegisterSuperAdmin(RegistrationRequest request)
    {
        try
        {
            var response = await _adminService.RegisterSuperAdminAsync(request);
            return response.Success ? Ok(response) : Conflict(response);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("delete-teacher-account")]
    public async Task<IActionResult> DeleteAccount(TeacherLoginRequest request)
    {
        try
        {
            await _adminService.DeleteAccountAsync(request);
            return Ok("Account deleted successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("delete-admin-account")]
    public async Task<IActionResult> DeleteAdminAccount(LoginRequest request)
    {
        try
        {
            await _adminService.DeleteAccountAsync(request);
            return Ok("Account deleted successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }

    [HttpDelete("delete-superadmin-account")]
    public async Task<IActionResult> DeleteSuperAdminAccount(TeacherLoginRequest request)
    {
        try
        {
            await _adminService.DeleteAccountAsync(request);
            return Ok("Account deleted successfully");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CustomException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request: {ex.Message}");
        }
    }
}