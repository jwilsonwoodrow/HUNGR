<template>
  <div>
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png" />
             <button class="select" @click="$router.push('/invite')">
      <strong> Create Invite </strong></button
    ><br />
        <div class="glass-container">
    <h4>Current Restaurant Options:</h4>
    <div
      class="empty-collection"
      v-show="$store.state.savedRestaurants.length === 0"
    >
      <p>
        This event currently has no restaurant selections. Please browse
        restaurants and use the [Add To Collection] button to add them as
        options.
      </p>
      <router-link class="searchLink" to="/restaurants"
        >Click here to search restaurants</router-link
      >
      <br />
    </div>
    <div
      class="collection-list"
      v-for="restaurant in $store.state.savedRestaurants"
      v-bind:key="restaurant.id"
      v-show="$store.state.savedRestaurants"
    >
      <img
            v-bind:src="restaurant.image_url"
            alt="No Image Available"
            width="200"
            height="190"
          />
          <div class="name-category">
            <strong>{{ restaurant.name }}</strong> -
            {{ restaurant.categories[0].title }}
          </div>
          <br />
          <div class="address">
            {{ restaurant.location.address1 }}<br />{{
              restaurant.location.city
            }}, {{ restaurant.location.state }} {{ restaurant.location.zip_code
            }}<br />
          </div>
          <div class="is-closed" v-show="!restaurant.is_closed">Open Now</div>
          <div class="is-closed" v-show="restaurant.is_closed">Closed</div>
          <a
            v-bind:href="'tel:' + restaurant.phone"
            v-show="!restaurant.is_closed"
          >
            Call Now</a
          ><br />
    </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "collection-display",
};
</script>
<style scoped>
.backgroundLogo {
  min-height: 100%;
  min-width: 1024px;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
  background-size: cover;
}
.glass-container {
  text-align: center;
  overflow: auto;
  max-width: 100%; /* or can do fit-content here?? */
  height: fit-content;
  color: white;
  display: flex;
  position: absolute;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: left;
  gap: 20px;
  border-radius: 10px;
  backdrop-filter: blur(5px);
  background-color: rgba(255, 0, 0, 0.131);
  box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
  border: 4px rgba(0, 0, 0, 0.3) solid;
  border-bottom: 4px rgba(40, 40, 40, 0.35) solid;
  border-right: 4px rgba(40, 40, 40, 0.35) solid;
  margin-right: 2.5%;
}
.searchLink {
  color: rgb(252,248,200);
}
</style>