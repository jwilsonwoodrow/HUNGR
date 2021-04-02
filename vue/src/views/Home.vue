<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
    <p>User Name: {{currentUser.username}}</p>
    <p>User Id: {{currentUser.userId}}</p>
    <p>Role: {{currentUser.role}}</p>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
  },
};
</script>
