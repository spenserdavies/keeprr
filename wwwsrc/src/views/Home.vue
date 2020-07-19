<template>
  <div class="home container-fluid text-success">
    <div class="row mt-4">
      <div class="col-4 pb-3 mx-auto border-bottom border-primary text-center text-success">
        <h1>WELCOME TO KEEPR</h1>
      </div>
    </div>

    <div class="row mt-3 justify-content-center">
      <div class="card-columns p-3">
        <KeepComponent v-for="keep in keeps" :key="keep.id" :keep="keep" />
        
      </div>
    </div>

  </div>
</template>

<script>
import KeepComponent from "@/components/KeepComponent.vue"
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps(){
      return this.$store.state.publicKeeps
    }
  },
  mounted(){
    this.$store.dispatch("getAllKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    KeepComponent
  }
};
</script>
<style>
.bgprimary{
    color: #FF993A;
}
.card-columns{
  column-count: 4;
}
.card{
  background-color: #EEEEEE;
}


/* sets card column width for mobile (: */
@media(min-width:576px){
  .card-columns{
    column-count: 1;
  }
}

@media(min-width:768px){
  .card-columns{
    column-count: 2;
  }
}

@media(min-width:992px){
  .card-columns{
    column-count: 3;
  }
}

@media(min-width:1200px){
  .card-columns{
    column-count: 4;
  }
}


</style>
