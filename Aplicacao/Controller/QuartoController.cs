using Aplicacao.Data;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controller;

[Route("aplicacao/quarto")]
[ApiController]

public class QuartoController : ControllerBase
{
    private readonly AppDataContext _context;

    public QuartoController(AppDataContext context) =>
    _context = context;

    [HttpGet]
    [Route("listar")]

    public IActionResult Listar()
    {
        try
        {   
            List<Quarto> quartos =  _context.Quartos.ToList();
            return Ok(quartos);
           
        } 
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]

        public IActionResult Cadastrar([FromBody] Quarto quarto)
        {
            try
            {
                _context.Quartos.Add(quarto);
                _context.SaveChanges();
                return Created("", quarto);
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [HttpPatch]
[Route("alterar/{id}")]
public IActionResult Alterar([FromRoute] int id, [FromBody] Quarto quartoAtualizado)
{
    try
    {
        var quarto = _context.Quartos.FirstOrDefault(q => q.Id == id);
        if (quarto == null)
        {
            return NotFound();
        }

        // Atualiza apenas as propriedades permitidas do quarto existente com base nos dados fornecidos no quartoAtualizado
        quarto.Numero = quartoAtualizado.Numero;
        quarto.EstaDisponivel = quartoAtualizado.EstaDisponivel;

        _context.SaveChanges();
        return Ok(quarto);
    }
    catch (Exception e)
    {
        return BadRequest(e.Message);
    }
}



    } 
