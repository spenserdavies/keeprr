<template>
    <div id="keep-component" class="keep-component card shadow text-dark">
          <img class="card-img-top" :src="keep.img">
          <div class="card-body">
            <button class="btn btn-secondary float-right mt-0">Keep</button>
            <h4 class="card-title">{{keep.name}}</h4>
            <button @click="deleteKeep" v-if="this.$route.name == 'home' && keep.userId == $auth.user.sub" class="btn btn-primary float-right mt-4">Delete</button>
            <p class="card-text my-3">{{keep.description}}</p>
            <small>Keeps: {{keep.keeps}}</small>
          </div>
        </div>
  
</template>

<script>
export default {
    name: "KeepComponent",
    props: [ "keep" ],
    methods: {
        deleteKeep(){
            console.log(this.keep);
            this.$store.dispatch("deleteKeep", this.keep)
        }
    },
}
</script>

<style>

</style>