<template>
  <div>
    <!-- display list of all events with current user's id -->
    <!-- clicking on list of object will go to invite details -->
    <div
      class="event-list"
      v-for="(event, index) in events"
      :key="event.title"
      @click="GetDetails(index)"
    >
      {{ events.title }}
    </div>
    <div class="event-details" v-show="displayDetails[index]"></div>
  </div>
</template>

<script>
import apiService from "../services/apiService";
export default {
  name: "events",
  data() {
    return {
      events: [],
      displayDetails: [],
    };
  },
  created() {
    apiService.GetEvents().then((response) => {
      for (let i = 0; i < response.data.length; i++) {
        if (this.events.titles.indexOf(response.data.inviteTitle) === -1) {
          this.events.titles.push(response.data.inviteTitle);
          this.events.id.push(response.data.inviteId);
        }
      }

      this.events.eventTitles = response.data;
    });
  },
  methods: {
    GetDetails(index) {
      this.displayDetails[index] = true;
    },
  },
  updated() {
    for (let i = 0; i < this.events.length; i++) {
      this.displayDetails[i] = false;
    }
  },
};
</script>

<style>
</style>