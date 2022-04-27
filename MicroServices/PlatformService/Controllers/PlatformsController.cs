using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms(){
            Console.WriteLine("Getting platforms");
            var content = this._repo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(content));
        }

        [HttpGet("{id}")]
        public ActionResult<PlatformReadDTO> Get(int id){
            var platform = this._repo.GetPlatformById(id);
            return Ok(_mapper.Map<PlatformReadDTO>(platform));
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> Create(PlatformCreateDTO platform){
            var platformToCreate = _mapper.Map<Platform>(platform);
            _repo.CreatePlatform(platformToCreate);
            _repo.SaveChanges();
            return Ok(_mapper.Map<PlatformReadDTO>(platformToCreate));
            
        }


    }
}