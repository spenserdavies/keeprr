<template>
  <div class="container">
      <div class="row">
          <div class="col-5 mx-auto text-center mt-4 border-bottom border-primary pb-3 text-success">
              <h1>All My Vaults</h1>
          </div>
      </div>
  </div>
</template>

<script>
import VaultComponent from "@/components/VaultComponent.vue"
export default {
    components: {
        VaultComponent
    },
    name: "vaults",
    mounted(){
        this.$store.dispatch("getVaults");
    },
    computed: {
      vaults(){
        return this.$store.state.vaults;
      }
    },

}
</script>

<style>

</style>