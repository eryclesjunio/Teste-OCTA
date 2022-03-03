using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroVeiculos.Application.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(IProprietarioService proprietarioService)
        {
            _proprietarioService = proprietarioService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProprietarioDTO proprietarioDto)
        {
            if (proprietarioDto == null)
                return NotFound();

            return Execute(() => _proprietarioService.Adicionar(proprietarioDto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProprietarioDTO proprietarioDto)
        {
            if (proprietarioDto == null)
                return NotFound();

            return Execute(() => _proprietarioService.Editar(proprietarioDto));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _proprietarioService.Obter());
        }

        [HttpGet("{cpfCnpj}")]
        public IActionResult Get(string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return NotFound();

            return Execute(() => _proprietarioService.Obter(cpfCnpj));
        }

        [HttpDelete("{cpfCnpj}")]
        public IActionResult Delete(string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return NotFound();

            Execute(() =>
            {
                _proprietarioService.Deletar(cpfCnpj);
                return true;
            });

            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
