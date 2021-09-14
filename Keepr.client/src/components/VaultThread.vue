<template>
  <div class="row">
    <div class="col-md-12 pt-4">
      <div class="d-flex align-items-center">
        <h1 class="m-0">
          Vaults
        </h1>
        <button type="button" class="btn text-primary" title="Create Vault" data-toggle="modal" data-target="#newVaultModal">
          <span class="fas fa-plus fa-lg"></span>
        </button>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-2 col-6"
         v-for="v in vaults"
         :key="v.id"
    >
      <VaultCard :vault="v" />
    </div>
  </div>
  <NewVaultModal />
</template>

<script>
export default {
  props: {
    vaults: {
      type: Array,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>

<style lang="scss" scoped>

</style>
