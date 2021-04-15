import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import ViewRestaurants from '../views/ViewRestaurants'
import SplashPage from '../views/SplashPage'
import Invite from '../views/Invite'
import Collection from '../views/Collection'
import InviteConfirmation from '../views/InviteConfirmation'
import InviteeView from '../views/InviteeView'
import ViewEvents from '../views/ViewEvents'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/home',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/restaurants",
      name: 'restaurants',
      component: ViewRestaurants
    },
    {
      path: "/",
      name: 'splash',
      component: SplashPage,
      meta: {
        requiresAuth: false
      }
    },
    
    {
      path: '/invite',
      name: 'invite',
      component: Invite,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/collection',
      name: 'collection',
      component: Collection,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/inviteconfirmation',
      name: 'invite-confirmationn',
      component: InviteConfirmation,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/invite/:id',
      name: 'invitee-view',
      component: InviteeView,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/events',
      name: 'events',
      component: ViewEvents,
      meta: {
        requiresAuth: true
      }

    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
