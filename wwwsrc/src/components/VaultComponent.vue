<template>
    <div id="vault-component">
        <div style="width: 25vw;" class="card vault-card shadow text-dark">
            <h4 class="p-2">{{vault.name}}</h4>
            <h5 class="p-2">{{vault.description}}</h5>
            <small>{{vault.userId}}</small>
            <div class="row">
                <div class="col-12">
                    <router-link :to="{ name: 'vault', params: {vaultId: vault.id} }">
                        <button class="btn btn-primary float-right m-2">View</button>
                    </router-link>
                    <button class="btn btn-secondary m-2" @click="deleteVault">Delete</button>
                </div>
            </div>
        </div>
    </div>  
</template>

<script>
export default {
    name: "VaultComponent",
    props: [ "vault" ],
    methods: {
        deleteVault(){
            let r = confirm("Delete This Vault? \nIt Cannot Be Undone");
            if(r == true){
                this.$store.dispatch("deleteVault", this.vault);
            }
        },
    },
}
</script>

<style>

</style>