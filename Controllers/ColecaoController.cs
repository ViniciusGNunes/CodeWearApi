using CodeWearApi.Data;
using CodeWearApi.DTOs.Colecoes;
using CodeWearApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("colecoes")]
public class ColecaoController : ControllerBase
{
    private readonly AppDataContext _context;

    public ColecaoController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColecaoModel>>> GetAll()
    {
        return await _context.Colecoes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ColecaoModel>> GetById(int id)
    {
        var colecao = await _context.Colecoes.FindAsync(id);
        if (colecao == null) return NotFound();
        return colecao;
    }

    [HttpPost]
    public async Task<ActionResult<ColecaoModel>> Create(ColecaoModel model)
    {
        _context.Colecoes.Add(model);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]ColecoesUpdateDto model)
    {

        var colecao = await _context.Colecoes.SingleOrDefaultAsync(X => X.Id == id);
        colecao.Nome = model.Nome;
        colecao.Descricao = model.Descricao;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw (ex);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var colecao = await _context.Colecoes.FindAsync(id);
        if (colecao == null) return NotFound();

        _context.Colecoes.Remove(colecao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
