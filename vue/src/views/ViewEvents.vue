<template>
  <!-- display list of all events with current user's id -->
  <!-- clicking on list of object will go to invite details -->
  <div>
    <p>hello</p>

  </div>
</template>

<script>
import apiService from "../services/apiService";
export default {
  name: "events",
  data() {
    return {
      eventTitles: [],
    };
  },
  created() {
    apiService.GetEventTitles().then((response) => {
      this.eventTitles = response.data;
    })
  },
};
</script>

<style>
</style>