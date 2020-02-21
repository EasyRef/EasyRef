import Vue from 'vue'
import Router from 'vue-router'
import Home from './components/Home.vue'
import Games from './components/Games.vue'
import Coach from './components/Coach.vue'
import Referee from './components/Referee.vue'
import GameCalendar from './components/GameCalendar.vue'


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
      }
  ]
})