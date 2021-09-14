import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfileById(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.profile = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vaults = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.keeps = res.data
  }
}

export const accountService = new AccountService()
