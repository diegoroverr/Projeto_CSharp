using System.Diagnostics;
using Aplicacao.Data;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controller;

    [Route("aplicacao/hospede")]
    [ApiController]
    public class HospedeController : ControllerBase
    {
        private readonly AppDataContext _context;

        public HospedeController(AppDataContext context) => 
        _context = context;

        [HttpGet]
        [Route("listar")]
        
        public IActionResult Listar()
        {
            try
            {
                if(_context.Hospedes != null)
                {
                List<Hospede> hospedes = _context.Hospedes.ToList();
                return Ok(hospedes);
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

        public IActionResult Cadastrar([FromBody] Hospede hospede)
        {
            try
            {
                if(_context.Hospedes != null)
                {
                _context.Hospedes.Add(hospede);
                _context.SaveChanges();
                return Created("", hospede);
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
public IActionResult Alterar([FromRoute] int id, [FromBody] Hospede hospedeAtualizado)
{
    try
    {
        var hospede = _context.Hospedes.FirstOrDefault(h => h.Id == id);
        if (hospede == null)
        {
            return NotFound();
        }

        // Atualiza apenas as propriedades permitidas do hospede existente com base nos dados fornecidos no hospedeAtualizado
        hospede.Email = hospedeAtualizado.Email;
        hospede.JaPagou = hospedeAtualizado.JaPagou;

        _context.SaveChanges();
        return Ok(hospede);
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}



    }
