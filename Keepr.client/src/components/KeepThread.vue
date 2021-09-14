<template>
  <div class="row">
    <div class="col-md-12 pt-4">
      <div class="d-flex align-items-center">
        <h1 class="m-0">
          Keeps
        </h1>
        <button type="button" class="btn text-primary" title="Create Keep" data-toggle="modal" data-target="#newKeepModal">
          <span class="fas fa-plus fa-lg"></span>
        </button>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="card-columns px-3">
      <div class="card rounded"
           data-toggle="modal"
           :data-target="'#KeepDetailsModal'+ k.id"
           v-for="k in keeps"
           :key="k.id"
      >
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
  <NewKeepModal />
</template>

<script>
export default {
  props: {
    keeps: {
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
@media (min-width: 576px) {
    .card-columns {
        column-count: 2;
    }
}

@media (min-width: 768px) {
    .card-columns {
        column-count: 4;
    }
}

@media (min-width: 992px) {
    .card-columns {
        column-count: 5;
    }
}

@media (min-width: 1200px) {
    .card-columns {
        column-count: 6;
    }
}
</style>
