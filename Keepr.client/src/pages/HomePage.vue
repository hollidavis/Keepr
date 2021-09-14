<template>
  <div class="container-fluid">
    <div class="card-columns">
      <div class="card rounded"
           data-toggle="modal"
           :data-target="'#KeepDetailsModal'+ k.id"
           v-for="k in keeps"
           :key="k.id"
      >
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import { accountService } from '../services/AccountService'
export default {
  setup() {
    watchEffect(async() => {
      try {
        keepsService.getAllKeeps()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    watchEffect(async() => {
      try {
        if (AppState.account.id) {
          accountService.getVaultsByProfileId(AppState.account.id)
        }
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style lang="scss" scoped>
@media (min-width: 576px) {
    .card-columns {
        column-count: 2;
    }
}

@media (min-width: 768px) {
    .card-columns {
        column-count: 3;
    }
}

@media (min-width: 992px) {
    .card-columns {
        column-count: 4;
    }
}
</style>
