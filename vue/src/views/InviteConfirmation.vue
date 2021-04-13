<template>
  <div>
    <section class="list">Confirmed Date Information</section>
    <button class="select" @click="$router.push('/invite')">
      <strong> Generate Link </strong></button
    ><br />
    <div class="link-box">Link Generation Box</div>
    <button class="select" @click="$router.push('/invite')">
      <strong> Send Invite</strong></button
    ><br />
  </div>
</template>

<script>
export default {
  name: "invite-confirmation",
  methods: {
    GenerateLink(){
      //generate event id 
      //save event info 
      //save restaurants with event id as FK 
      //generate link using event id 
      //present link to user
    },
  }
};
</script>

<style>
</style>