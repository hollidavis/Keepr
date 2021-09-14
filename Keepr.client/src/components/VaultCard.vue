<template>
  <div class="card card-size rounded mt-3">
    <img class="card-img rounded" :src="vault.img" :alt="vault.name">
    <div class="card-img-overlay black-gradient rounded">
      <h4 class="text-light text-shadow m-0 pointer" @click.stop="vaultDetails">
        {{ vault.name }}
      </h4>
    </div>
  </div>
</template>

<script>
import { router } from '../router'
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      vaultDetails() {
        router.push({ name: 'Vault', params: { id: props.vault.creator.id } })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.card-size{
  height: 25vh;
  width: 100%;
}
.card-img{
  height: 25vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
.profile{
  height: 7vh;
  width: 7vh;
}
</style>
