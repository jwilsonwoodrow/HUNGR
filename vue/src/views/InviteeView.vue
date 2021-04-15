<template>
  <div>
    TEST
    <!-- display event name, location, time, date -->
     {{event.name}}{{event.location}}{{event.time}}{{event.date}}<br>
    <!-- prompt for invitee name  -->
    <!-- <label for="eventName"> What is the name of your Event? </label><br>
      <input
        v-model="invite.inviteTitle"
        id="eventName"
        type="text"
        name="eventName"
      /> 
    <!-- must be inaccessable after deadline -->
    <!-- list preselected restaurants (from database?) with up/down vote options -->
    <!-- submit -->
  </div>
</template>
<script>
export default {
  name: "invitee-view",
  data(){
    return {
      event:{},
    }
  },
 created() { 
    console.log(this.$route.params.id)
}
};
</script>
<style>
</style>