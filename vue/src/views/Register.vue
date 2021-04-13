<template>
  <div id="register" class="body">
    <registration-form>  </registration-form>
  </div>
</template>

<script>
import RegistrationForm from '@/components/RegistrationForm.vue';

export default {
  name: "register",
  
  components: {
    RegistrationForm,
  }
  ,
};
</script>

<style scoped>
.alert-danger {
  color: red;
}
</style>
