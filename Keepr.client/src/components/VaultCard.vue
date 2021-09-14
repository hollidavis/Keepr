<template>
  <div class="card card-size rounded mt-3">
    <img class="card-img rounded" :src="vault.img" :alt="vault.name">
    <div class="card-img-overlay black-gradient rounded">
      <h3 class="text-light text-shadow m-0 pointer" @click.stop="vaultDetails">
        {{ vault.name }}
      </h3>
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
        router.push({ name: 'Vault', params: { id: props.vault.id } })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.card-size{
  height: 20vh;
  width: 100%;
}
.card-img{
  height: 20vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
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
