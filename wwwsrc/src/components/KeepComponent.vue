<template>
    <div id="keep-component">
        <div class="card shadow text-dark" :class="{ 'bg-primary' : isHomeAndMyKeep == true}">
          <img class="card-img-top" :src="keep.img">
          <div class="card-body">
            <button class="btn btn-secondary float-right mt-0">Keep</button>
            <h4 class="card-title" >{{keep.name}}</h4>
            <button @click="deleteKeep" v-if="this.$route.name == 'dashboard' && keep.userId == $auth.user.sub" class="btn btn-primary float-right mt-4">Delete</button>
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
            console.log(this.keep);
            let r = confirm("Delete This Keep? \nIt Cannot Be Undone")
            if(r == true){
                this.$store.dispatch("deleteKeep", this.keep)
            }
        }
    },
    computed: {
        isHomeAndMyKeep(){
            return this.$route.name == 'home' && this.keep.userId == this.$auth.user.sub
        }
    }
}
</script>

<style>

</style>