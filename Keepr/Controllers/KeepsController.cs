using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _keepsService;

        public KeepsController(KeepsService keepsService)
        {
            _keepsService = keepsService;
        }

        [HttpGet]
        public ActionResult<List<Keep>> Get(){
            try
            {
                 List<Keep> keeps = _keepsService.Get();
                 return Ok(keeps);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
        {
            try
            {
                 Keep keep = _keepsService.Get(id);
                 return Ok(keep);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}