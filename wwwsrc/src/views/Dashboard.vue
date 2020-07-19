<template>
  <div class="dashboard text-success">
    <div class="container">
      <div class="row mt-4">
        <div class="col-6 mx-auto pb-3 border-bottom border-primary text-center">
          <h1>DASHBOARD</h1>
        </div>
        
      </div>
      <div class="row mt-5">
        <div class="col-7 mx-auto text-center">
          <form v-if="form" @submit.prevent="addKeep">
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
            <label for="check">Set As Private?</label>
            <input type="checkbox" class="p-2 m-2" id="check" v-model="newKeep.IsPrivate" />

            <button type="submit" class="btn btn-primary float-right m-2 text-secondary border-secondary">Submit</button>
            <button class="btn btn-secondary float-right m-2 text-primary border-secondary" @click="clearForm">Cancel</button>
             
          </form>
        </div>
      </div>
    </div>
    
    <div class="container-fluid">
      .<div class="row">
        <div class="col-5 mx-auto border-bottom border-primary text-center">
          <h3>My Keeps</h3>
        </div>      
      </div>
      <div class="row">
        <div class="col-5 mx-auto border-bottom border-primary">
          <button class="btn btn-primary ml-0 my-2" @click="form = !form">New</button>
          <button v-if="viewKeeps == false" class="btn btn-success float-right m-2" @click="viewKeeps = true">Show</button>
          <button v-if="viewKeeps == true" class="btn btn-secondary text-primary2 float-right m-2" @click="viewKeeps = false">Hide</button>
        </div>
      </div>
      <div class="row mt-4" v-if="viewKeeps ==true">
        <div class="card-columns">
          <KeepComponent v-for="keep in myKeeps" :key="keep.id" :keep="keep" />
        </div>
      </div>

    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->

    </div>
  </div>
</template>

<script>
import KeepComponent from "@/components/KeepComponent.vue"
export default {
  components: {
    KeepComponent,
  },
  name: "dashboard",
  data() {
    return {
      newKeep: {},
      form: false,
      viewKeeps: false,
      viewMyVauls: false,
    };
  },
  mounted() {},
  computed: {
    keeps(){
      return this.$store.state.publicKeeps;
    },
    myKeeps(){
      return this.$store.state.publicKeeps.filter(keep => keep.userId == this.$auth.user.sub);
    }
  },
  methods: {
    clearForm(){
      this.newKeep = {};
      this.form = false;
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
      this.clearForm();
    }
  }
};
</script>

<style>

</style>
