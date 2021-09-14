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
                  <div class="col-12 d-flex justify-content-center align-items-center">
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
                    <!-- Select Vault -->
                    <div class="row w-100">
                      <div class="col-md-6 d-flex align-items-center">
                        <form @submit.prevent="addKeepToVault" class="mr-auto">
                          <select v-model="state.vault" class="pointer">
                            <option v-for="v in vaults" :key="v.id" :value="v">
                              {{ v.name }}
                            </option>
                            <option v-if="!vaults.length">
                              No Vaults Yet
                            </option>
                          </select>
                          <button type="submit" class="btn text-primary py-0 px-2">
                            <span class="fas fa-save fa-lg"></span>
                          </button>
                        </form>
                        <!-- Delete -->
                        <button type="button" class="btn text-danger py-0 px-2" @click.stop="">
                          <span class="fas fa-trash-alt fa-lg"></span>
                        </button>
                      </div>
                      <!-- Creator Info -->
                      <div class="col-md-6 d-flex align-items-center">
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
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
      vault: {}
    })
    return {
      state,
      vaults: computed(() => AppState.vaults)
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
