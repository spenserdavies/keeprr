<template>
  
</template>

<script>
export default {
    name: "VaultForm",
    // props: [ "vaultForm" ],
    data(){
        return{
            newVault: {},
        }
    },
    methods: {
        clearVaultForm(){
            this.newVault = {};
            this.vaultForm = true;
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

</style>