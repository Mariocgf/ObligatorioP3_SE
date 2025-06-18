﻿using Compartido.DTOs;
using Compartido.DTOs.Usuario;
using Compartido.Exceptions;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using WebAPI.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Hacer la inyeccion de dato
        private readonly IUsuarioLogin _usuarioLogin;
        private readonly ICambiarPassword _cambiarPassword;
        public UsuarioController(IUsuarioLogin usuarioLogin, ICambiarPassword cambiarPassword)
        {
            _usuarioLogin = usuarioLogin;
            _cambiarPassword = cambiarPassword;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                if (loginDto == null)
                    return BadRequest("Datos vacios");
                UsuarioLoggedDTO usuarioDto = _usuarioLogin.Login(loginDto);
                if (usuarioDto == null)
                    return BadRequest("Datos vacios");
                usuarioDto.Token = ManejadorToken.CrearToken(usuarioDto);
                return Ok(usuarioDto);
            }
            catch (UsuarioException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error interno del servidor :)");
            }
        }
        // PUT api/<UsuarioController>/
        [HttpPut]
        public IActionResult ChangePassword([FromBody] CambioPasswordDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos vacios");
                _cambiarPassword.Ejecutar(dto);
                return Ok("Cambio realizado con exito");
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch(ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
