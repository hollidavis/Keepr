import { reactive } from 'vue'

export const AppState = reactive({
  user: {},
  account: {},
  profile: {},
  keeps: [],
  activeVault: {},
  vaults: [],
  vaultKeeps: []
})
