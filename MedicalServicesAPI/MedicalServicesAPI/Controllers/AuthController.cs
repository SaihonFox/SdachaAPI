using System.ComponentModel.DataAnnotations;
using MedicalServicesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServicesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	[HttpGet("login")]
	public ActionResult<user> Get([Required]string login, [Required]string password)
	{
		var users = Program.ctx.users.ToList();
		user? finded_user;
		if((finded_user = users.FirstOrDefault(u => u.password == password && u.login.Equals(login, StringComparison.CurrentCultureIgnoreCase))) != null)
			return Ok(finded_user);
		return NotFound("User not found");
	}
}