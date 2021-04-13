<template>
  <div>
    <button class="select" @click="$router.push('/home')">
      <strong> go back </strong>
    </button> <br/>
    <button
      class="clear-collection"
      v-show="!$store.state.savedRestaurants == ''"
      @click="ClearCollection"
    >    
      <strong>Clear Collection </strong>
    </button>
    <br />
    <collection-display />
    <br />
  </div>
</template>
<script>
import CollectionDisplay from "../components/CollectionDisplay.vue";
export default {
  components: { CollectionDisplay },
  methods: {
    ClearCollection() {
      this.$store.commit("CLEAR_SAVED_RESTAURANTS");
    },
  },
};
</script>
<style scoped>
.backgroundLogo {
  min-height: 100%;
  min-width: 1024px;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -2;
  background-size: cover;
}
</style>