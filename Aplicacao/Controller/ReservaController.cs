using Aplicacao.Data;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controller;

[Route("aplicacao/reserva")]
[ApiController]

public class ReservaController : ControllerBase
{
    private readonly AppDataContext _context;
    public ReservaController(AppDataContext context) => 
    _context = context;

    [HttpGet]
    [Route("listar")]
        
        public IActionResult Listar()
        {
            try
            {
                if(_context.Reservas != null)
                {
                List<Reserva> reservas = _context.Reservas.ToList();
                return Ok(reservas);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [HttpPost]
    [Route("cadastrar")]

        public IActionResult Cadastrar([FromBody] Reserva reserva)
        {
            try
            {
                if(_context.Reservas != null)
                {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return Created("", reserva);
                }
                else
                {
                    return NotFound();
                }
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [HttpPatch]
[Route("alterar/{id}")]
public IActionResult Alterar([FromRoute] int id, [FromBody] Reserva reservaAtualizada)
{
    try
    {
        var reserva = _context.Reservas.FirstOrDefault(r => r.Id == id);
        if (reserva == null)
        {
            return NotFound();
        }

        // Atualiza as propriedades da reserva existente com base nos dados fornecidos na reservaAtualizada
        reserva.Quarto = reservaAtualizada.Quarto;
        reserva.DataEntrada = reservaAtualizada.DataEntrada;
        reserva.DataSaida = reservaAtualizada.DataSaida;
        reserva.NumeroDaReserva = reservaAtualizada.NumeroDaReserva;

        _context.SaveChanges();
        return Ok(reserva);
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}

}