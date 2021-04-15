<template>
  <div>
    <div class="nav">
      <button class="go-back" @click="$router.push('/home')">
        <strong> go back </strong>
      </button>
      <br />
      <button
        class="go-back"
        v-show="!$store.state.savedRestaurants == ''"
        @click="ClearCollection"
      >
        <strong>Clear Collection </strong>
      </button>
      <br />
      <button class="go-back" @click="$router.push('/invite')">
        <strong> Create Event </strong>
      </button>
    </div>
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
.nav {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-evenly;
}
.go-back {
  color: darkred;
  border: 3px solid darkred;
  border-radius: 25px;
  box-shadow: 2px 2px 8px 4px rgba(0, 0, 0, 0.74);
  background: white;
  padding: 5px;
  margin-bottom: 5px;
}
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