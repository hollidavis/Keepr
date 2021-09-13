<template>
  <img class="card-img" :src="keep.img" :alt="keep.name">
  <div class="card-img-overlay black-gradient">
    <h2 class="text-light">
      {{ keep.name }}
    </h2>
    <!-- <img :src="keep.creator.picture" :alt="keep.creator.name"> -->
  </div>
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

</style>
