<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-primary">
    <router-link class="navbar-brand ml-3 mr-5" :to="{ name: 'home' }">
      <div class="row my-0 py-0 ">
        <div class="col-12 text-center py-0 my-0">
          <h1 class="keepr-k text-center my-0 py-0">K</h1>
        </div>
      </div>
      <div class="row mt-0 pt-0">
        <div class="col-12 text-center mt-0 pt-0">
          <small>keepr</small>
        </div>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }">Dashboard</router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button class="btn btn-success shadow mr-3" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn btn-danger shadow mr-3 " @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style>

.keepr-k{
  font-family: 'Pacifico', cursive;
}
* :not(.keepr-k){
  font-family: 'Roboto', sans-serif;
}
</style>
