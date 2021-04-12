<template>
  <div>
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
      <router-link to="/restaurants"
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
      <tr>
        <th></th>
        <th></th>
      </tr>
      <tr>
        <td>
          <img
            v-bind:src="restaurant.image_url"
            alt="No Image Available"
            width="200"
            height="190"
          />
        </td>
        <td class="name-category">
          {{ restaurant.name }} <br />
          <!-- <br />{{ restaurant.categories[0].title }} -->
        </td>
        <td class="address">
          {{ restaurant.location.address1 }}<br />{{
            restaurant.location.city
          }}, {{ restaurant.location.state }} {{ restaurant.location.zip_code
          }}<br />
        </td>
        <td>
          <ul>
            <div class="is-closed" v-show="!restaurant.is_closed">Open Now</div>
            <div class="is-closed" v-show="restaurant.is_closed">Closed</div>
          </ul>
        </td>
        <a
          v-bind:href="'tel:' + restaurant.phone"
          v-show="!restaurant.is_closed"
        >
          Call Now</a
        >
        <td></td>
      </tr>
    </div>
  </div>
</template>

<script>
export default {
  name: "collection-display",
};
</script>

<style>
</style>