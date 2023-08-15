using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using FilmesApi.Repositories;
using FilmesApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    public readonly IFilmeService _service;

    public FilmeController(IFilmeService service)
    {
        _service = service;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
    {
      _service.Adiciona(filmeDTO);
            
     return StatusCode(StatusCodes.Status201Created);
    }

    /// <summary>
    /// Recupera todos os filmes salvos no banco de dados com limites de paginação
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <param name="filmeDTO"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso recuperação seja feita com sucesso</response>

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> RecuperaFilmes([FromQuery]int take = 10)
    {
        return _service.Recupera(take);
    }

    /// <summary>
    /// Recupera um filme específico salvo no banco de dados
    /// </summary>
    /// <param name="filmeDTO"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso recuperação seja feita com sucesso</response>

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        var filme = _service.RecuperaPorId(id);

        if (filme == null) return NotFound();
    
        return Ok(filme);
    }

    /// <summary>
    /// Atualiza um filme no banco de dados passando todos os parâmetros
    /// </summary>
    /// <param name="filmeDTO"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso recuperação seja feita com sucesso</response>

    [HttpPut("{id}")]

    public IActionResult AtualizaFilme(int id,
        [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _service.RecuperaPorId(id);
        
        if (filme == null) return NotFound();

        _service.Atualiza(id, filmeDTO);

        return NoContent();
    }

    /// <summary>
    /// Atualiza um filme específico salvo no banco de dados, passando um único parâmetro
    /// </summary>
    /// <param name="filmeDTO"></param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a atualização seja feita com sucesso</response>

    [HttpPatch("{id}")]

    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        var filmeDTO = _service.RecuperaUpdateParcial(id);

        if (filmeDTO == null) return NotFound();

        patch.ApplyTo(filmeDTO, ModelState);

        if (!TryValidateModel(filmeDTO))
        {
            return ValidationProblem(ModelState);
        }

        _service.Atualiza(id, filmeDTO);

        return NoContent();
    }

    /// <summary>
    /// Remove um filme específico salvo no banco de dados, passando um único parâmetro
    /// </summary>
    /// <param name="filmeDTO"></param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a remoção seja feita com sucesso</response>

    [HttpDelete("{id}")]

    public IActionResult DeletaFilme(int id)
    {
        var filme = _service.RecuperaPorId(id);

        if (filme == null) return NotFound();

        _service.Remove(id);

        return NoContent();

    }


}
        