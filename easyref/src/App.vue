<template>

<div class="container">
 
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="">{{title}}</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <router-link class="nav-link" to="/games">Matcher</router-link>       
      </li>
      <li>
         <router-link class="nav-link" to="/calendar">Kalender</router-link>
       
      </li>
      <li>
         <router-link class="nav-link" to="/coach">Tränare</router-link>
      </li><li>
        <router-link class="nav-link" to="/referee">Domare</router-link>
        </li>

    
    </ul>
 

  </div>
</nav>


 

<router-view/>
</div>

</template>

<script>


export default {
  name: 'app',
  components: {
  
  },
  data() {
    return {
      title: process.env.VUE_APP_TITLE
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Montserrat:400,700');
@import "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"; 

body {
  background-color:#092c52 !important;
  font-family: 'Montserrat', sans-serif !important;
}
.game-header {
  color: white;
  margin-top: 0.5em;
  margin-bottom: 0.5em;
}
</style>
