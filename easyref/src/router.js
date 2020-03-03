import Vue from 'vue'
import Router from 'vue-router'
import Home from './components/Home.vue'
import Games from './components/Games.vue'
import Coach from './components/Coach.vue'
import Referee from './components/Referee.vue'
import Login from './components/Login.vue'
import GameCalendar from './components/GameCalendar.vue'
import Admin from './components/Admin.vue'
import Contact from './components/Contact.vue'
import About from './components/About.vue'
import UserDetails from './components/UserDetails.vue'
import ContactInfo from './components/ContactInfo.vue'
import AddUser from './components/AddUser.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/calendar',
      name: 'calendar',
      component: GameCalendar
    },
    {
        path: '/games',
        name: 'games',
        component: Games
      },
      {
        path: '/coach',
        name: 'coach',
        component: Coach
      },
      {
        path: '/Referee',
        name: 'referee',
        component: Referee
      },
      {
      path: '/Login',
      name: 'login',
      component: Login
      },
      {
        path: '/Admin',
        name: 'admin',
        component: Admin
      },
      {
        path: '/Contact',
        name: 'contact',
        component: Contact
      },
      {
        path: '/About',
        name: 'about',
        component: About
      },
      {
        path: '/UserDetails/:coachId',
        name: 'UserDetails',
        component: UserDetails,
        props: true,
      },
      //  {
      //    path: '/UserDetails',
      //    name: 'userDetailsById',
      //    component: UserDetails
      //  },
      {
        path: '/ContactInfo',
        name: 'contactInfo',
        component: ContactInfo
      },
      {
        path: '/AddUser',
        name: 'addUser',
        component: AddUser
      },
  ]
})