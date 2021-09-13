using System;
using System.Collections.Generic;
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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vaultsService;
        private readonly VaultKeepsService _vaultKeepsService;

        public VaultsController(VaultsService vaultsService, VaultKeepsService vaultKeepsService)
        {
            _vaultsService = vaultsService;
            _vaultKeepsService = vaultKeepsService;
        }
        
        [HttpGet("{vaultId}/keeps")]
        public ActionResult<List<VaultKeepViewModel>> GetKeeps(int vaultId)
        {
            try
            {
                 List<VaultKeepViewModel> vaultKeeps = _vaultKeepsService.GetVaultKeeps(vaultId);
                 return Ok(vaultKeeps);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vault>> GetAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Vault vault = _vaultsService.Get(id, userInfo?.Id);
                return Ok(vault);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newVault.CreatorId = userInfo.Id;
                Vault vault = _vaultsService.Create(newVault);
                return Ok(vault);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Edit([FromBody] Vault updatedVault, int id)
        {
            try
            {
                 Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                 updatedVault.CreatorId = userInfo.Id;
                 updatedVault.Id = id;
                 Vault vault = _vaultsService.Edit(updatedVault);
                 return Ok(vault);
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
                _vaultsService.Delete(id, userInfo.Id);
                return Ok("Successfully Deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}