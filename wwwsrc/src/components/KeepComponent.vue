<template>
    <div id="keep-component">
        <div class="card shadow text-dark" > <!-- :class="{ 'bg-primary' : isHomeAndMyKeep == true}" -->
          <img class="card-img-top" :src="keep.img">
          <div class="card-body">
            <button v-if="$auth.isAuthenticated && this.$route.name != 'vault'" class="btn btn-secondary float-right mt-0 dropdown-toggle" type="button" id="keep-button" data-toggle="dropdown">Keep</button>
            <div class="dropdown-menu bg-info">
                <p @click="keepThis(keep.id, vault.id)" class="dropdown-item pointer text-white" v-for="vault in vaults" :key="vault.id">{{vault.name}}</p>
            </div>
            <button v-if="this.$route.name == 'vault'" class="btn btn-primary float-right mt-0" @click="removeVaultKeep">Remove</button>
            <h4 class="card-title" >{{keep.name}}</h4>
            <button @click="deleteKeep" v-if="this.$route.name == 'dashboard' || this.$route.name == 'keeps'" class="btn btn-primary float-right mt-4">Delete</button>
            <p class="card-text my-3">{{keep.description}}</p>
            <small>Keeps: {{keep.keeps}}</small>
          </div>
        </div>
        </div>
  
</template>

<script>
export default {
    name: "KeepComponent",
    props: [ "keep" ],
    data(){
        return{
            
        }
    },
    methods: {
        deleteKeep(){
            let r = confirm("Delete This Keep? \nIt Cannot Be Undone")
            if(r == true){
                this.$store.dispatch("deleteKeep", this.keep)
            }
        },
        keepThis(keepId, vaultId){
            let newVaultKeep = {
                vaultId,
                keepId
            }
            this.keep.keeps += 1;
            console.log(this.keep.keeps)
            let editedKeep = this.keep
            console.log(editedKeep)
            console.log("keepId: " + keepId);
            console.log("vaultId: "+ vaultId)
            this.$store.dispatch("addKeepToVault", newVaultKeep)
            this.$store.dispatch("increaseKeepCount", editedKeep);
        },
        removeVaultKeep(){
            // debugger;
            let vaultId = this.$route.params.vaultId;
            console.log(this.keep)
            let r = confirm("Remove From This Vault?")
            let delObj = { keep: this.keep , vaultId: vaultId }
            if(r == true){
                this.$store.dispatch("deleteVaultKeep", delObj)
            // this.$store.dispatch("getKeepsByVaultId", vaultId)
            }
        }
    },
    computed: {
        isHomeAndMyKeep(){
            return this.$route.name == 'home' && this.keep.userId == this.$auth.user.sub
        },
        vaults(){
            return this.$store.state.vaults;
        }
    },
    mounted(){
        if(this.$auth.isAuthenticated){
            this.$store.dispatch("getVaults")
        }
    }
}
</script>

<style>
.pointer{
    cursor: pointer;
}
</style>