using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _accountService;
    public ProfilesController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{profileId}")]

    public ActionResult<Profile> GetProfileById(string id)
        {
            try
            {
                 Profile profile = _accountService.GetProfileById(id);
                 return Ok(profile);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Profile>> GetProfileKeeps(string profileId)
        {
            try
            {
                 List<Keep> keeps = _accountService.GetProfileKeeps(profileId);
                 return Ok(keeps);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
  }
}