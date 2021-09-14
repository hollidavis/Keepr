import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async addKeepToVault(vault, keep) {
    const body = {
      vaultId: vault.id,
      keepId: keep.id
    }
    await api.post('api/vaultkeeps', body)
    const found = AppState.keeps.find(k => k.id === keep.id)
    found.keeps++
  }

  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.vaults.push(res.data)
  }

  async deleteVault(id) {
    await api.delete('api/vaults/' + id)
    const found = AppState.vaults.filter(v => v.id !== id)
    AppState.vaults = found
  }
}

export const vaultsService = new VaultsService()
