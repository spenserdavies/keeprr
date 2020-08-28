import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
import Keeps from "./views/Keeps.vue";
import Vault from "./views/Vault.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/keeps",
      name: "keeps",
      component: Keeps,
      beforeEnter: authGuard
    },
    {
      path: "/vault/:vaultId",
      name: "vault",
      component: Vault,
      beforeEnter: authGuard
    },
  ]
});


