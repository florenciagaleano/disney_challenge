using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDisney.Data;
using WebAPIDisney.Models;
using SendGrid;

namespace WebAPIDisney.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<Usuario> userManager;
        private MailService mail;

        public UsuarioController(ApplicationDbContext context, UserManager<Usuario> userManager, MailService mail)
        {
            this.context = context;
            this.userManager = userManager;
            this.mail = mail;
        }

        //[HttpPost("register")]
        //public async Task<object> RegisterAsync(Usuario usuario)
        //{
        //    //var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        //    //var result = await userManager.CreateAsync(user, model.Password);

        //    //if (result.Succeeded)
        //    //{
        //    //    await _mailService.SendEmail(model.Email);
        //    //    return await GenerateToken(usuario);
        //    //}
        //    //else
        //    //    return BadRequest(result.Errors);
        //}

        //            usuario.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}{1}{2}", "testapi", DateTime.Today.ToShortDateString(), DateTime.Today.ToShortTimeString())));
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usuario user)
        {
            var response = await userManager.FindByEmailAsync(user.Email);

            if(response != null)
            {
                //return StatusCode(500);//el usuario ya existe
                return Redirect("login");
            }

            Usuario nuevoUsuario = new Usuario
            {
                Email = user.Email,
                Password = user.Password,
            };

            var res = await userManager.CreateAsync(nuevoUsuario, user.Password);
            if (res.Succeeded)
            {
                //await mail
                return Ok();
            }

            return StatusCode(500,"Problemas para crear al usuario");//no se pudo crear al usuario
        }


        [HttpPost("login")]
        public IActionResult Login(Usuario login)
        {
            var log = context.Usuarios.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Usuario invalido", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "Login exitoso", UserDetails = log });
        }


    }
}
