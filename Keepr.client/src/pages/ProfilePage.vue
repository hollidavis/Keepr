<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 d-flex">
        <img :src="profile.picture" :alt="profile.name" class="profile rounded">
        <div class="ml-4 text-break">
          <h1>{{ profile.name }}</h1>
          <h4>Vaults: {{ vaults.length }}</h4>
          <h4>Keeps: {{ keeps.length }}</h4>
        </div>
      </div>
    </div>
    <VaultThread :vaults="vaults" />
    <KeepThread :keeps="keeps" />
  </div>
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { accountService } from '../services/AccountService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      try {
        if (route.params.id) {
          accountService.getProfileById(route.params.id)
          accountService.getVaultsByProfileId(route.params.id)
          accountService.getKeepsByProfileId(route.params.id)
        }
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      route,
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style lang="scss" scoped>
.profile{
  height: 20vh;
  width: 20vh;
}
</style>
