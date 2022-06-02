﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pre_aceleracion_Rodrigo_Roman.Context;
using Pre_aceleracion_Rodrigo_Roman.Interfaces;
using Pre_aceleracion_Rodrigo_Roman.Models;
using Pre_aceleracion_Rodrigo_Roman.ViewModels.Characters;

namespace Pre_aceleracion_Rodrigo_Roman.Controllers
{
    //decoradores para índicar que es una api y ruta y especificar las rutas 
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase //hereda de la clase base para tener las funcionalidades
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly DisneyContext _context;

        public CharactersController(ICharactersRepository repository, DisneyContext context1)
        {
            _charactersRepository = repository;
            _context = context1;
        }

        [HttpGet]
        [Route("search_character")]
        public async Task<IActionResult> SerachCharacters([FromQuery] CharacterRequestDetailViewModel model)
        {

            var characters = _context.Characters.Include(x => x.MovieSeries).ToList();

            if (!string.IsNullOrEmpty(model.Name))
            {
                characters = characters.Where(x => x.Name == model.Name).ToList();
            }

            if (!string.IsNullOrEmpty(model.Age.ToString()))
            {
                characters = characters.Where(x => x.Age == model.Age).ToList();
            }

            if (model.MovieSeriesID.Any())
            {
                characters = characters.Where(x => x.MovieSeries.Any(y => model.MovieSeriesID.Contains(y.ID))).ToList();
            }

            if (!characters.Any()) return NoContent();

            var responseViewModel = new List<CharacterResponsetDetailViewModel>();

            foreach (var character in characters)
            {
                responseViewModel.Add(new CharacterResponsetDetailViewModel()
                {
                    Image = character.Image,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    Lore = character.Lore,
                    RelatedMovies = character.MovieSeries.Select(x => x.Title).ToList()
                });
            }
            return Ok(responseViewModel);
        }

        [HttpGet]
        [Route("detail_characters")]
        public async Task<IActionResult> CharactersDetails()
        {
            var characters = _context.Characters.Include(x => x.MovieSeries).ToList();
            if (!characters.Any()) return NoContent();
            var responseViewModel = new List<CharactersDetailsResponseViewModel>();
            foreach (var character in characters)
            {
                responseViewModel.Add(new CharactersDetailsResponseViewModel()
                {
                    ID = character.ID,
                    Image = character.Image,
                    Name = character.Name,
                    Age = (int)character.Age,
                    Weight = (float)character.Weight,
                    Lore = character.Lore,
                    RelatedMovies = character.MovieSeries.Select(x => x.Title).ToList()
                });
            }
            return Ok(responseViewModel);
        }

        [HttpGet]
        [Route("characters")]
        [Authorize(Roles = "Admin")]
        public IActionResult DetallesPersonajes()
        {
            var characters = _context.Characters.ToList();
            if (!characters.Any()) return NoContent();
            var responseViewModel = new List<CharactersGetResponseViewModel>();
            foreach (var character in characters)
            {
                responseViewModel.Add(new CharactersGetResponseViewModel()
                {
                    Image = character.Image,
                    Name = character.Name
                });
            }
            return Ok(responseViewModel);
        }

        [HttpGet]
        [Route("all_characters")]
        public IActionResult GetAllCharacters()
        {
            var characters = _context.Characters.Include(x => x.MovieSeries).ToList();

            var responseViewModel = new List<CharacterResponsetDetailViewModel>();

            foreach (var character in characters)
            {
                responseViewModel.Add(new CharacterResponsetDetailViewModel()
                {
                    Image = character.Image,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    Lore = character.Lore,
                    RelatedMovies = character.MovieSeries.Select(x => x.Title).ToList()
                });
            }
            return Ok(responseViewModel);
        }

        [HttpPost]
        [Route("create_character")]
        public async Task<IActionResult> PostCharacter(CharacterPostRequestViewModel charact)
        {
            //se genera una entidad del modelo con los datos minimos para llenar los campos del ViewModel
            Characters character = new Characters
            {
                Image = charact.Image,
                Name = charact.Name,
                Age = charact.Age,
                Weight = charact.Weight,
                Lore = charact.Lore
            };

            //se añade al contexto se guardan cambios y se retorna
            _charactersRepository.Add(character);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
            //return Ok(_context.Characters.Include(x => x.MovieSeries.Select(x => x.Title)).ToList());

        }

        [HttpPut]
        [Route("update_character")]
        public IActionResult PutCharacter(CharacterPutRequestViewModel character)
        {

            if (_context.Characters.FirstOrDefault(x => x.ID == character.ID) == null)
                return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(character.ID);

            auxCharacter.Image = character.Image;
            auxCharacter.Name = character.Name;
            auxCharacter.Weight = character.Weight;
            auxCharacter.Age = character.Age;
            auxCharacter.Lore = character.Lore;

            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }

        [HttpDelete]
        [Route("delete_character/{id}")]

        public IActionResult DeleteCharact(int id)
        {
            if (_context.Characters.FirstOrDefault(x => x.ID == id) == null) return BadRequest("El personaje no existe.");

            var auxCharacter = _context.Characters.Find(id);

            _context.Characters.Remove(auxCharacter);
            _context.SaveChanges();
            return Ok(_context.Characters.ToList());
        }
    }

}
