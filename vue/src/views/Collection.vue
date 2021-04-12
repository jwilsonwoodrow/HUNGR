<template>
  <div>
      <button class="select" @click="$router.push('/home')"><strong> go back </strong></button><br>
      <button class="clear-collection" @click="ClearCollection"><strong>Clear Collection </strong></button>
      <section class="list">List of Saved Restaurants:</section>
      <br>
      <collection-display/>
      <br>
      <button class="select" @click="$router.push('/invite')"><strong> Create Invite </strong></button><br>
  </div>
</template>

<script>
import CollectionDisplay from '../components/CollectionDisplay.vue'
export default {
  components: { CollectionDisplay },
  methods: {
    ClearCollection(){
      this.$store.commit('CLEAR_SAVED_RESTAURANTS')
    }
  }
}
</script>

<style>

</style>