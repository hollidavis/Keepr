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
        <div class="modal-body p-2">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-6 p-0 d-flex justify-content-start">
                <img class="img-fluid hero-img rounded" :src="keep.img" :alt="keep.name">
              </div>
              <div class="col-md-6 p-0">
                <!-- Keep Stats -->
                <div class="row">
                  <div class="col-12 d-flex justify-content-center">
                    <p><span class="fas fa-eye"></span> {{ keep.views }}</p>
                    <p class="px-3">
                      <span class="fab fa-korvue"></span> {{ keep.keeps }}
                    </p>
                    <p><span class="fas fa-share"></span> {{ keep.shares }}</p>
                  </div>
                </div>
                <!-- Keep Text -->
                <div class="row justify-content-center align-items-center">
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
                  <div class="col-12 d-flex">
                    <div>
                      <form @click.prevent="">
                        <select name="cars" id="cars" form="carform">
                          <option value="volvo">
                            Volvo
                          </option>
                          <option value="saab">
                            Saab
                          </option>
                          <option value="opel">
                            Opel
                          </option>
                          <option value="audi">
                            Audi
                          </option>
                        </select>
                      </form>
                    </div>
                    <div>
                      <button type="button" class="btn text-danger" @click.prevent="">
                        <span class="fas fa-trash-alt"></span>
                      </button>
                    </div>
                    <div class="d-flex align-items-center">
                      <p class="m-0 pr-2">
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
.profile{
  height: 7vh;
  width: 7vh;
}
.hero-img{
  max-height: 80vh;
}
.line{
  border-bottom: 2px 2px black;
}
</style>
