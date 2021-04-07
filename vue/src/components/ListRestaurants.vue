<template>
  <input type="search" placeholder="Type City or Zip" v-model="location"/>
  <input type=""/>
</template>

<script>
import apiService from '../services/apiService';

export default {
    data() {
        return {
        location: '',
        category: '',
        cuisine: ['Mexican',
        'French',
        'American',
        'Chinese',
        'Vietnamese',
        'Italian',
        'Korean',
        'Japanese',
        'Texmex',
        'Breakfast & Brunch',
        'Indian',
        'Mediterranean',
        'Polish',
        'Greek',
        'Middle-Eastern',
        'Lebanese',
        'Barbeque',
        'Thai',
        'Cupcakes',
        'Dessert',
        'Ethiopian',
        'Jamacian',
        'Caribbean',
        'Coffee',
        'Tea',
        'Bar',
        'Tavern',
        'Pizza'
        ],
        };
    },
    created() {
        apiService.getBusinessByLocationAndOrCategory(this.$)
    },
    methods: {

    },
    computed: {

    },
}
</script>

<style>

</style>