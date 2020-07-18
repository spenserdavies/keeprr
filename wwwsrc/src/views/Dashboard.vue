<template>
  <div class="dashboard text-success">
    <div class="container">
      <div class="row mt-4">
        <div class="col-4 offset-4 pb-3 border-bottom border-primary text-center">
          <h1>DASHBOARD</h1>
        </div>
        <div class="col-4">
          <button class="btn btn-primary float-right" @click="form = !form">New</button>
        </div>
      </div>
      <div class="row mt-5">
        <div class="col-7 mx-auto">
          <form v-if="form" @submit.prevent="addKeep">
            <input
              class="form-control my-2"
              type="text"
              placeholder="Image Url"
              v-model="newKeep.Img"
            />
            <input class="form-control my-2" type="text" placeholder="Name" v-model="newKeep.Name" />
            <input
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
    {{keeps}}
    <div class="container-fluid">
    {{ newKeep }}
    <img :src="newKeep.Img" />

    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->

    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newKeep: {},
      form: false
    };
  },
  mounted() {},
  computed: {
    keeps(){
      return this.$store.state.publicKeeps;
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
    }
  }
};
</script>

<style></style>
