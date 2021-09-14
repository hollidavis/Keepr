<template>
  <img class="card-img rounded pointer" :src="keep.img" :alt="keep.name" @click="increaseViewCount">
  <div class="card-img-overlay black-gradient rounded pointer" @click="increaseViewCount">
    <div class="d-flex justify-content-between align-items-center">
      <h3 class="text-light m-0 text-shadow">
        {{ keep.name }}
      </h3>
      <img class="rounded-pill profile" :src="keep.creator.picture" :alt="keep.creator.name">
    </div>
  </div>
  <KeepDetailsModal :keep="keep" />
</template>

<script>
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async increaseViewCount() {
        try {
          keepsService.getById(props.keep.id)
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
