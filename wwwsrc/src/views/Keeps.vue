<template>
  <div class="container-fluid">
          <div class="row mt-5"></div>
    <div class="row mt-5 py-1"></div>
      <div class="row">
          <div class="col-5 mx-auto text-center mt-4 border-bottom border-primary pb-3 text-success">
              <h1>All My Keeps</h1>
          </div>
      </div>
      <div class="row mt-3">
          <div class="card-columns">
              <KeepComponent v-for="keep in keeps" :key="keep.id" :keep="keep" />
          </div>
      </div>
  </div>
</template>

<script>
import KeepComponent from "@/components/KeepComponent.vue"
export default {
    components: {
        KeepComponent
    },
    name: "keeps",
    mounted(){
        this.$store.dispatch("getAllKeeps");
    },
    computed: {
        keeps() {
            return this.$store.state.publicKeeps.filter(keep => keep.userId == this.$auth.user.sub);

        }
    }

}
</script>

<style>

</style>