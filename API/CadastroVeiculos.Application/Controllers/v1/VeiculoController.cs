using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroVeiculos.Application.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] VeiculoDTO veiculoDto)
        {
            if (veiculoDto == null)
                return NotFound();

            return Execute(() => _veiculoService.Adicionar(veiculoDto));
        }

        [HttpPut]
        public IActionResult Update([FromBody] VeiculoDTO veiculoDto)
        {
            if (veiculoDto == null)
                return NotFound();

            return Execute(() => _veiculoService.Editar(veiculoDto));
        }

        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                return NotFound();

            Execute(() =>
            {
                _veiculoService.Deletar(placa);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _veiculoService.Obter());
        }

        [HttpGet("{placa}")]
        public IActionResult Get(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                return NotFound();

            return Execute(() => _veiculoService.Obter(placa));
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
