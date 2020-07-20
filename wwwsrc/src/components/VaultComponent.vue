<template>
    <div id="vault-component">
        <div style="width: 50vw;" class="card vault-card shadow text-dark">
            <h4 class="p-2">{{vault.name}}</h4>
            <h5 class="p-2">{{vault.description}}</h5>
            <button class="btn btn-primary float-right m-2">View</button>
            <button class="btn btn-secondary m-2" @click="deleteVault">Delete</button>
        </div>
    </div>  
</template>

<script>
export default {
    name: "VaultComponent",
    props: [ "vault" ],
    methods: {
        deleteVault(){
            this.$store.dispatch("deleteVault", this.vault);
        },
    },
}
</script>

<style>

</style>