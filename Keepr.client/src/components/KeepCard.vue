<template>
  <img class="card-img rounded pointer" :src="keep.img" :alt="keep.name">
  <div class="card-img-overlay black-gradient rounded pointer">
    <div class="d-flex justify-content-between align-items-center">
      <h2 class="text-light m-0">
        {{ keep.name }}
      </h2>
      <img class="rounded-pill profile" :src="keep.creator.picture" :alt="keep.creator.name">
    </div>
  </div>
  <KeepDetailsModal :keep="keep" />
</template>

<script>
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>

<style lang="scss" scoped>
.black-gradient{
  background-image: linear-gradient(rgb(0, 0, 0), rgba(0, 0, 0, 0));
  min-height: 25%;
  max-height: 50%;
}

.profile{
  height: 7vh;
  width: 7vh;
}
</style>
