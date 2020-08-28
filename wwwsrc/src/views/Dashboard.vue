<template>
  <div class="dashboard text-success" id="top">
    <div class="container">
          <div class="row mt-5"></div>
    <div class="row mt-5 py-1"></div>
      <div class="row mt-4">
        <div class="col-6 mx-auto pb-3 border-bottom border-primary text-center">
          <h1>DASHBOARD</h1>
        </div>
        
      </div>
      <div class="row mt-5">
        <div class="col-7 mx-auto text-center">

          <form v-if="keepForm" @submit.prevent="addKeep">
          <h3>New Keep</h3>
            <input
              class="form-control my-2"
              type="text"
              placeholder="Image Url"
              v-model="newKeep.Img"
              required
            />
            <input required class="form-control my-2" type="text" placeholder="Name" v-model="newKeep.Name" />
            <input
            required
              class="form-control my-2"
              type="text"
              placeholder="Description"
              v-model="newKeep.Description"
            />
            <!-- <label for="check" class="ml-0">Set As Private?</label>
            <input type="checkbox" class="p-2 m-2 ml-0" id="check" v-model="newKeep.IsPrivate" /> -->

            <button type="submit" class="btn btn-primary float-right m-2 text-secondary border-secondary">Submit</button>
            <button class="btn btn-secondary float-right m-2 text-primary border-secondary" @click="clearKeepForm">Cancel</button>
             
          </form>
          
          

        </div>
      </div>
    </div>
    
    <div class="container-fluid mb-5">
      
      <div class="row">
        <div class="col-5 mx-auto border p-3 bg-danger border-primary text-center shadow title-shadow">
          <h3>My Keeps</h3>
        </div>      
      </div>
      <div class="row">
        <div class="col-5 mx-auto d-flex justify-content-between">
          <button class="btn btn-primary my-2" @click="keepForm = !keepForm ; vaultForm = false">New</button>
          <router-link :to="{ name: 'keeps' }">
            <button class="btn btn-success mx-auto my-2" >View All</button>
          </router-link>
          <button v-if="viewKeeps == false" class="btn btn-success float-right m-2" @click="viewKeeps = true">Show</button>
          <button v-if="viewKeeps == true" class="btn btn-secondary text-primary float-right m-2" @click="viewKeeps = false">Hide</button>
        </div>
      </div>
      <div class="row mt-4" v-if="viewKeeps ==true">
        <div class="card-columns mx-auto">
          <KeepComponent v-for="keep in myKeeps" :key="keep.id" :keep="keep" />
        </div>
      </div>
    </div>

    <div class="container-fluid mt-5">
      <div class="row">
        <div class="col-5 mx-auto">
          <div>
            <form @submit.prevent="addVault" v-if="vaultForm">
          <h3>New Vault</h3>
            <input required class="form-control my-2" type="text" placeholder="Name" v-model="newVault.Name" />
            <input
            required
              class="form-control my-2"
              type="text"
              placeholder="Description"
              v-model="newVault.Description"
            />
            <button type="submit" class="btn btn-primary float-right m-2 text-secondary border-secondary">Submit</button>
            <button class="btn btn-secondary float-right m-2 text-primary border-secondary" @click="clearVaultForm">Cancel</button>
             
          </form>
          </div>
        </div>
      </div>
      <div class="row mt-5">
        <div class="col-5 mx-auto border p-3 bg-danger border-primary text-center">
          <h3>My Vaults</h3>
        </div>
      </div>
      <div class="row">
        <div class="col-5 mx-auto  d-flex justify-content-between">
            <button class="btn btn-primary ml-0 my-2" @click="vaultForm = true ; keepForm = false ; viewKeeps = false" >New</button>
          <button v-if="viewVaults == false" class="btn btn-success float-right m-2" @click="viewVaults = true">Show</button>
          <button v-if="viewVaults == true" class="btn btn-secondary text-primary float-right m-2" @click="viewVaults = false">Hide</button>
        </div>
      </div>
      <div class="row mt-4" v-if="viewVaults == true">
        <div class="card-columns vault-cards mx-auto">
          <VaultComponent v-for="vault in vaults" :key="vault.id" :vault="vault" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from "@/components/KeepComponent.vue"
import VaultComponent from "@/components/VaultComponent.vue"
import VaultForm from "@/components/VaultForm.vue"
export default {
  components: {
    KeepComponent,
    VaultComponent,
   

  },
  name: "dashboard",
  data() {
    return {
      newKeep: { isPrivate: false },
      newVault: {},
      keepForm: false,
      vaultForm: false,
      viewKeeps: true,
      viewVaults: true,
    };
  },
  mounted() {
    this.$store.dispatch("getMyKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps(){
      return this.$store.state.myKeeps;
    },
    myKeeps(){
      return this.$store.state.myKeeps.filter(keep => keep.userId == this.$auth.user.sub).splice(0,4);
    },
    vaults(){
      return this.$store.state.vaults;
    }
  },
  methods: {
    clearKeepForm(){
      this.newKeep = { isPrivate: false };
      this.keepForm = false;
    },
    clearVaultForm(){
      this.newVault = {};
      this.vaultForm = false;
    },
    addKeep() {
      if(this.newKeep.IsPrivate == true){
        console.log("private keep added");
        this.$store.dispatch("addKeep", this.newKeep);
      }
      else{
        console.log("public keep added");
        this.$store.dispatch("addKeep", this.newKeep);
      }
      this.clearKeepForm();
      this.viewKeeps = true;
    },
    addVault(){
      this.$store.dispatch("addVault", this.newVault)
      this.clearVaultForm();
      this.viewVaults = true;
    },
    
  }
}
</script>

<style>
.card-columns.vault-cards{
  column-count: 3;
}



</style>
