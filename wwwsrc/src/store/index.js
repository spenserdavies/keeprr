import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { api } from "./AxiosService";
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    myKeeps: [],
    vaults: [],
    activeVault: {},
    activeVaultKeeps: [],
  },
  mutations: {
    setKeeps(state, keeps){
      state.publicKeeps = keeps;
    },
    setMyKeeps(state, keeps){
      state.myKeeps = keeps;
    },
    setVaults(state, vaults){
      state.vaults = vaults
    },
    setActiveVault(state, vaultId){
      state.activeVault = state.vaults.filter(vault => vault.id == vaultId).pop();
      console.log(state.activeVault);
    },
    setActiveVaultKeeps(state, vaultKeeps){
      state.activeVaultKeeps = vaultKeeps;
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
    async getMyKeeps({commit}){
      try {
        let res = await api.get("keeps/user");
        commit("setMyKeeps", res.data);
      } catch (error) {
        console.error(error)
      }
    },
    async addKeep({commit, dispatch}, newKeep){
      let res = await api.post("keeps", newKeep);
      dispatch("getMyKeeps");
    },
    async deleteKeep({commit, dispatch}, keepToDelete){
      try{
      let res = await api.delete("keeps/" + keepToDelete.id, keepToDelete);
      dispatch("getMyKeeps");
      }catch(err){
        console.error(err);
      }
    },
    async addKeepToVault({commit, dispatch}, newVaultKeep){
      try {
        let res = await api.post("vaultkeeps", newVaultKeep)
        console.log(res)
      } catch (err) {
        console.error(err)
      }
    },
    async increaseKeepCount({commit, dispatch}, editedKeep){
      try {
        let res = await api.put("keeps/" + editedKeep.id, editedKeep);
        dispatch("getAllKeeps");
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVaultKeep({commit,dispatch}, keepObj){
      try {
        // debugger;
        let res = await api.delete("vaultkeeps/" + keepObj.keep.vaultKeepId)
        dispatch("getKeepsByVaultId", keepObj.vaultId);
      } catch (error) {
        console.error(error)
      }
    },
    async getVaults({commit}){
      try {
        let res = await api.get("vaults/user");
        commit("setVaults", res.data)
      } catch (err) {
        console.error(err);
      }
    },
    async addVault({dispatch}, newVault){
      let res = await api.post("vaults", newVault);
      dispatch("getVaults");
      console.log(res)
    },
    async deleteVault({dispatch}, vaultToDelete){
      try{
        let res = await api.delete("vaults/" + vaultToDelete.id, vaultToDelete);
        dispatch("getVaults");
      }catch(err){
        console.error(err);
      }
    },
    getActiveVault({commit}, vaultId){
      commit("setActiveVault", vaultId);
    },
    async getKeepsByVaultId({commit, dispatch}, vaultId){
      try {
        // debugger;
        let res = await api.get("vaults/" + vaultId + "/keeps");
        console.log(res)
        commit("setActiveVaultKeeps", res.data);
      } catch (err) {
        console.error(err)
      }
    }
  }
});
