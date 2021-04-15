<template>
  <div class="body">
    <label> What is the name of your Event? </label>
    <input type="text" name="EventName" />
    <label> What day do you want to meet?</label>
    <input type="datetime-local" name="date" /> <br />
    <label> RSVP by? </label>
    <input type="datetime-local" name="rsvp" />
  </div>
</template>

<script>
export default {
  name: "event-info-form",
};
</script>

<style scoped>
.body {
  align-items: center;
}
</style>