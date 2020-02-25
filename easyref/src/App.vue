<template>
<div>

  
 <header class="header-color">
   <div class="container">
  <nav class="navbar navbar-expand-lg header-color">
  <a class="navbar-brand" href="">{{title}}</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item">
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
</div>
</header>
<div class="container-fluid">

 
<AddGame/>
<router-view/>

</div>
</div>

</template>

<script>
import AddGame from './components/AddGame.vue'

export default {
  name: 'app',
  components: {
  AddGame
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

.game-btn {
    background-color: #092c52 !important;
    border: 1px solid #ffffff !important;
    color: white !important;
}
.game-btn:hover {
    background-color: #1b518b !important;
}
.game-header {
   text-transform: uppercase;
    border: 1px solid #ffffff;
    padding: 20px;
    text-align:left;
    background-color: #092c52;
    color: white;
    text-transform: uppercase;
    border-radius: 6px;
     margin-top: 0.5em;
  margin-bottom: 0.5em;
    background-image: linear-gradient(#0e3f75,#092c52);

/* background-image: linear-gradient(#b52d2d,#f53e3e); */
  
}
.container {
  width: 40% !important;
}

.game-btn {
    background-color: #092c52;
    border: 1px solid #ffffff;; 
}

.header-color {
  background-color: #041930;
  font-weight: bold;
  color: red;
  text-transform: uppercase;
  
}

.header-color a {
  color: white;
}

.header-color a:active {
  color: green !important;
}

.navbar-nav > .active {
  color: green;
}

.head-div h2  {
 
    text-transform: uppercase;
    font-size: 18px;
    padding: 20px;
    text-align:left;
    background-color: #092c52;
    color: white;
    text-transform: uppercase;
    border-radius: 6px;
    margin-bottom: 2px;
    background-image: linear-gradient(#0e3f75,#092c52);
}


</style>
