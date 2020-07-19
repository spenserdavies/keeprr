import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { api } from "./AxiosService";
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    publicKeeps: []
  },
  mutations: {
    setKeeps(state, keeps){
      state.publicKeeps = keeps;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getAllKeeps({commit}){
      try {
        let res = await api.get("keeps");
        commit("setKeeps", res.data)
      } catch (err) {
        console.error(err);
      }
    },
    async addKeep({commit, dispatch}, newKeep){
      let res = await api.post("keeps", newKeep);
      dispatch("getAllKeeps");
    },
    async deleteKeep({commit, dispatch}, keepToDelete){
      try{
      let res = await api.delete("keeps/" + keepToDelete.id, keepToDelete);
      dispatch("getAllKeeps");
      }catch(err){
        console.error(err);
      }
    }
  }
});
