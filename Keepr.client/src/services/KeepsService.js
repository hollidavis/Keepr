import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getById(id) {
    await api.get('api/keeps/' + id)
    const found = AppState.keeps.find(k => k.id === id)
    found.views++
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    const found = AppState.keeps.filter(k => k.id !== id)
    AppState.keeps = found
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    AppState.keeps.push(res.data)
  }
}

export const keepsService = new KeepsService()
