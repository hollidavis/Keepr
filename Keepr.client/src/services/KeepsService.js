import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async GetById(id) {
    await api.get('api/keeps/' + id)
    const found = AppState.keeps.find(k => k.id === id)
    found.views++
  }
}

export const keepsService = new KeepsService()
