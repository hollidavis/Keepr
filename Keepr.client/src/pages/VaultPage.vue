<template>
  <div class="container-fluid" v-if="state.authorized == true">
    <div class="row">
      <div class="col-md-12 pb-3">
        <div class="d-flex align-items-center">
          <h1 class="m-0">
            {{ vault.name }}
          </h1>
          <button type="button" class="btn text-danger" @click.stop="deleteVault" v-if="vault.creatorId == account.id" :title="'Delete '+vault.name">
            <span class="fas fa-trash-alt fa-lg"></span>
          </button>
        </div>
        <h4>Keeps: {{ keeps.length }}</h4>
      </div>
    </div>
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
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
import { router } from '../router'
export default {
  setup() {
    const route = useRoute()
    const state = reactive({
      authorized: false
    })
    onMounted(async() => {
      try {
        if (route.params.id) {
          await vaultsService.getById(route.params.id)
          await vaultsService.getKeepsByVaultId(route.params.id)
          state.authorized = true
        }
      } catch (error) {
        Pop.toast(error, 'error')
        router.push({ name: 'Home' })
      }
    })
    return {
      state,
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account),
      async deleteVault() {
        try {
          if (await Pop.confirm()) {
            await vaultsService.deleteVault(route.params.id)
            router.push({ name: 'Home' })
            Pop.toast('Successfully Deleted', 'error')
          }
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
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
