using System.ComponentModel.DataAnnotations;
using MedicalServicesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServicesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	[HttpGet("login")]
	public ActionResult<User> Get([Required]string login, [Required]string password)
	{
		var users = Program.ctx.Users.ToList();
		User? finded_user;
		if((finded_user = users.Find(u => u.Password == password && u.Login.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase))) != null)
			return Ok(finded_user);
		return NotFound("User not found");
	}
}