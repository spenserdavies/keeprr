<template>
  <div class="container-fluid text-success">
    <div class="row mt-5"></div>
    <div class="row mt-5 py-1"></div>
    <div class="row mt-0 py-3 border-bottom border-primary bg-danger">
      <div class="col-5 my-auto">
        <h2 class="ml-3">{{vault.name}}</h2>
      </div>
      <div class="col-2 d-flex justify-content-end my-auto py-3">
        <h3>
          <u>Description:</u>
        </h3>
      </div>
      <div class="col-5 ml-0 my-auto pt-2 vault-desc">
        <h5>{{vault.description}}</h5>
      </div>
    </div>
    <div class="row">
        <div class="col-5 mx-auto pb-3 mt-3 border-bottom border-primary text-success text-center">
            <h1>Keeps In This Vault</h1>
        </div>
    </div>
    <div class="row mt-5">
        <div class="card-columns">
            <KeepComponent v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" :keep="vaultKeep" />
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
  name: "vault",
  mounted() {
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps(){
        return this.$store.state.activeVaultKeeps
    }
  },
};
</script>

<style>
</style>