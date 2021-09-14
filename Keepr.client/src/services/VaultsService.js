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
}

export const vaultsService = new VaultsService()
