using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vaultKeepsService;
        private readonly VaultsService _vaultsService;
        private readonly KeepsService _keepsService;

        public VaultKeepsController(VaultKeepsService vaultKeepsService, VaultsService vaultsService, KeepsService keepsService)
        {
            _vaultKeepsService = vaultKeepsService;
            _vaultsService = vaultsService;
            _keepsService = keepsService;
        }

        [HttpGet("{id}")]
        public ActionResult<VaultKeep> GetOne(int id)
        {
            try
            {
                VaultKeep group = _vaultKeepsService.GetOne(id);
                return Ok(group);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newVaultKeep.CreatorId = userInfo.Id;
                Vault vault = _vaultsService.Get(newVaultKeep.VaultId, newVaultKeep.CreatorId);
                Keep keep = _keepsService.GetOne(newVaultKeep.KeepId);
                _keepsService.IncreaseKeepCount(keep);
                if(vault != null){
                    VaultKeep vaultKeep = _vaultKeepsService.Create(newVaultKeep);
                    return Ok(vaultKeep);
                } else {
                    throw new Exception("Something went wrong...");
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                VaultKeep toBeDeleted = _vaultKeepsService.GetOne(id);
                Keep keep = _keepsService.GetOne(toBeDeleted.KeepId);
                _vaultKeepsService.Delete(id, userInfo.Id);
                _keepsService.DecreaseKeepCount(keep);
                return Ok("Successfully Deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}