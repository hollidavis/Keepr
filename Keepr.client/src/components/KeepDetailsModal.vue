<template>
  <div class="modal fade"
       :id="'KeepDetailsModal'+ keep.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-xl modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header p-2">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close" title="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body p-2" @click.stop="increaseViewCount">
          <div class="container-fluid">
            <div class="row">
              <!-- Img -->
              <div class="col-md-6 p-0">
                <img class="img-fluid hero-img rounded" :src="keep.img" :alt="keep.name">
              </div>
              <!-- Info -->
              <div class="col-md-6 d-flex flex-column">
                <!-- Keep Stats -->
                <div class="row">
                  <div class="col-12 d-flex justify-content-center align-items-center pt-2">
                    <p><span class="fas fa-eye fa-lg"></span> {{ keep.views }}</p>
                    <p class="px-3">
                      <span class="fab fa-korvue fa-lg"></span> {{ keep.keeps }}
                    </p>
                    <p><span class="fas fa-share fa-lg"></span> {{ keep.shares }}</p>
                  </div>
                </div>
                <!-- Keep Text -->
                <div class="row d-flex justify-content-center flex-grow-1">
                  <div class="col-9">
                    <h1 class="text-center">
                      {{ keep.name }}
                    </h1>
                    <p class="text-left">
                      {{ keep.description }}
                    </p>
                  </div>
                </div>
                <!-- Keep Buttons -->
                <div class="row">
                  <div class="col-12 d-flex align-items-center justify-content-center">
                    <div class="row w-100">
                      <!-- Vault/Delete -->
                      <div class="col-md-6 d-flex align-items-center justify-content-center pt-2">
                        <!-- Vault Form -->
                        <form @submit.prevent="addKeepToVault" class="d-flex mr-auto">
                          <div class="mb-4">
                            <small :id="'keepHelp'+keep.id" class="text-muted">Add to Vault</small>
                            <select v-model="state.vault" class="pointer w-100" :aria-describedby="'keepHelp'+keep.id" required>
                              <option v-for="v in vaults" :key="v.id" :value="v">
                                {{ v.name }}
                              </option>
                              <option v-if="!vaults.length">
                                No Vaults Yet
                              </option>
                            </select>
                          </div>
                          <button type="submit" class="btn text-primary py-0 px-2" title="Submit">
                            <span class="fas fa-save fa-lg"></span>
                          </button>
                        </form>
                        <!-- Delete -->
                        <button type="button" class="btn text-danger py-0 px-2" :title="'Delete '+ keep.name" @click.stop="deleteKeep" v-if="keep.creatorId == account.id">
                          <span class="fas fa-trash-alt fa-lg"></span>
                        </button>
                      </div>
                      <!-- Creator Info -->
                      <div class="col-md-6 d-flex align-items-center justify-content-center pb-2 pointer" :title="'Go To '+ keep.creator.name + ' Profile Page'" @click.stop="profile">
                        <p class="m-0 px-2 mr-auto">
                          {{ keep.creator.name }}
                        </p>
                        <img class="rounded-pill profile" :src="keep.creator.picture" :alt="keep.creator.name">
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import $ from 'jquery'
import { keepsService } from '../services/KeepsService'
import { router } from '../router'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      vault: {}
    })
    return {
      state,
      vaults: computed(() => AppState.vaults),
      account: computed(() => AppState.account),
      async addKeepToVault() {
        try {
          vaultsService.addKeepToVault(state.vault, props.keep)
          state.vault = {}
          Pop.toast('Added to Vault', 'success')
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      async deleteKeep() {
        try {
          if (await Pop.confirm()) {
            $('#KeepDetailsModal' + props.keep.id).modal('hide')
            await keepsService.deleteKeep(props.keep.id)
            Pop.toast('Successfully Deleted', 'error')
          }
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      profile() {
        $('#KeepDetailsModal' + props.keep.id).modal('hide')
        router.push({ name: 'Profile', params: { id: props.keep.creator.id } })
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
.hero-img{
  max-height: 80vh;
  min-width: 100%;
  object-fit: cover;
  object-position: center;
}
.line{
  border-bottom: 2px 2px black;
}
</style>
