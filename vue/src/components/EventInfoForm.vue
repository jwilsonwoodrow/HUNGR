<template>
  <div>
    <form action="https://example.com">
      s
    </form>
    <form action="https://example.com">
      <label>
        What day do you want to meet?
        <input type="datetime-local" name="date" /> </label
      ><br />
      <label>
        RSVP by?
        <input type="datetime-local" name="rsvp" />
      </label>
    </form>
  </div>
</template>

<script>
export default {
  name: "event-info-form",
};
</script>

<style>
</style>