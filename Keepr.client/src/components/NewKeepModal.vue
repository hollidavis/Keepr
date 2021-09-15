<template>
  <div class="modal fade"
       id="newKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="modelTitleId"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            New Keep
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep">
            <!-- Title/Name -->
            <div class="form-group">
              <label for="name">Title</label>
              <input type="text"
                     name="name"
                     v-model="state.keep.name"
                     class="form-control"
                     placeholder="Title..."
                     required
              >
            </div>
            <!-- Description -->
            <div class="form-group">
              <label for="description">Description</label>
              <input type="text"
                     name="description"
                     v-model="state.keep.description"
                     class="form-control"
                     placeholder="Description..."
              >
            </div>
            <!-- Img Url -->
            <div class="form-group">
              <label for="image">Image Url</label>
              <input type="text"
                     name="image"
                     v-model="state.keep.img"
                     class="form-control"
                     placeholder="URL..."
                     required
              >
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
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'
export default {
  setup() {
    const state = reactive({
      keep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.keep)
          state.keep = {}
          $('#newKeepModal').modal('hide')
          Pop.toast('Keep Created!', 'success')
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
