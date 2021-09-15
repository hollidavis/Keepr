<template>
  <img class="card-img rounded pointer" :src="keep.img" :alt="keep.name" @click="increaseViewCount">
  <div class="card-img-overlay black-gradient rounded pointer d-flex justify-content-between align-items-start" @click="increaseViewCount">
    <h3 class="text-light m-0 text-shadow">
      {{ keep.name }}
    </h3>
    <img class="rounded-pill profile" :src="keep.creator.picture" :alt="keep.creator.name">
    <button type="button" class="btn text-danger p-0" v-if="route.params.id == vault.id && vault.creatorId == account.id" @click.stop="removeKeepFromVault" :title="'Remove ' + keep.name + ' from Vault'">
      <span class="fas fa-times"></span>
    </button>
  </div>
  <KeepDetailsModal :keep="keep" />
</template>

<script>
import { computed } from '@vue/runtime-core'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    return {
      route,
      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      async increaseViewCount() {
        try {
          keepsService.getById(props.keep.id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      async removeKeepFromVault() {
        try {
          if (await Pop.confirm()) {
            vaultsService.removeKeepFromVault(props.keep.vaultKeepId)
            Pop.toast('Successfully Removed', 'error')
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
.profile{
  height: 7vh;
  width: 7vh;
}
.hide {
  display: none;
}

.creator:hover + .hide {
  display: block;
}
</style>
