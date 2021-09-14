import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }

  async addKeepToVault(vault, keep) {
    const body = {
      vaultId: vault.id,
      keepId: keep.id
    }
    await api.post('api/vaultkeeps', body)
  }
}

export const vaultsService = new VaultsService()
