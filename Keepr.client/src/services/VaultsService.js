import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }
}

export const vaultsService = new VaultsService()
