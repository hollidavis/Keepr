using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
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

    public ActionResult<Profile> GetProfileById(string profileId)
        {
            try
            {
                 Profile profile = _accountService.GetProfileById(profileId);
                 return Ok(profile);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetProfileKeeps(string profileId)
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

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetProfileVaults(string profileId)
        {
            try
            {
                 Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                 List<Vault> vaults = _accountService.GetProfileVaults(profileId, userInfo?.Id);
                 return Ok(vaults);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
  }
}