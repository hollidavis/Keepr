<template>
  <div class="modal fade"
       id="newVaultModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault">
            <div class="form-group">
              <label for="title">Title</label>
              <input type="text"
                     name="title"
                     v-model="state.vault.name"
                     class="form-control"
                     placeholder="Title..."
                     required
              >
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input type="text"
                     name="description"
                     v-model="state.vault.description"
                     class="form-control"
                     placeholder="Title..."
              >
            </div>
            <div class="form-group">
              <label for="image">Image Url</label>
              <input type="text"
                     name="image"
                     v-model="state.vault.img"
                     class="form-control"
                     placeholder="URL..."
                     required
              >
            </div>
            <div class="form-group">
              <div class="d-flex align-items-center">
                <label for="private" class="m-0 pr-2">Private?</label>
                <input type="checkbox" v-model="state.vault.isPrivate" name="private" aria-describedby="privateHelpId">
              </div>
              <small id="privateHelpId" class="text-muted">Private vaults can only be seen by you</small>
            </div>
            <div class="d-flex justify-content-end">
              <button type="submit" class="btn btn-primary">
                Create
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'
export default {
  setup() {
    const state = reactive({
      vault: {}
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.vault)
          state.vault = {}
          $('#newVaultModal').modal('hide')
          Pop.toast('Vault Created!', 'success')
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
