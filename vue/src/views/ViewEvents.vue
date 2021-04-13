<template>
  <!-- display list of all events with current user's id --> 
  <!-- clicking on list of object will go to invite details -->
  <div></div>
</template>

<script>
import apiService from '../services/apiService';
export default {
  data(){
    return{
      eventTitles: [],
    }

  },
  created: {
    this.eventTitles = apiService.GetEventTitlesById()
  }
};
</script>

<style>
</style>