<template>
  <div class="container-fluid">
    <!-- <div class="card-columns">
      <div class="card rounded"
           data-toggle="modal"
           :data-target="'#KeepDetailsModal'+ k.id"
           v-for="k in keeps"
           :key="k.id"
      >
        <KeepCard :keep="k" />
      </div>
    </div> -->
  </div>
  <!-- <KeepDetailsModal /> -->
</template>

<script>
import { computed, watchEffect } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  setup() {
    const route = useRoute()
    watchEffect(() => {
      try {
        vaultsService.getById(route.params.id)
        // keepsService.getKeepsByVaultId(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      vault: computed(() => AppState.activeVault),
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
