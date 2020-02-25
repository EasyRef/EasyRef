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

:root{
    --easyref-red: #cc3828;
    --easyref-redBg: #cc3828;
    --easyref-bg: #d4d4d4;
    --easyref-bg-darken: #ab2d1f;
    --easyref-white: #ffffff;
    --easyref-firstRef: #32e02f;
    --easyref-secondRef:#f2ec29;
    --easyRef-thirdRef: #f01313;
    --easyRef-coach: #bcbda8;
    --easyref-calFunc: #fbff03 ;
}

body {
  background-color:var(--easyref-bg) !important;
  font-family: 'Montserrat', sans-serif !important;
}

.game-btn {
    background-color: var(--easyref-red)!important;
    border: 1px solid #ffffff !important;
    color: white !important;
    text-transform: uppercase;
}
.game-btn:hover {
    background-color: var(--easyref-bg-darken) !important;
}
.game-header {
   text-transform: uppercase;
    border: 1px solid #ffffff;
    padding: 20px;
    text-align:left;
    background-color: var(--easyref-bg);
    color: white;
    text-transform: uppercase;
    border-radius: 6px;
     margin-top: 0.5em;
  margin-bottom: 0.5em;
    background-image: linear-gradient(var(--easyref-red),var(--easyref-bg-darken));

/* background-image: linear-gradient(#b52d2d,#f53e3e); */


}
.timeGridDay-btn {
  color: var(--easyref-bg) !important;
}  
.container {
  width: 100% !important;
 
}

.game-btn {
    background-color: var(--easyref-red);
    border: 1px solid #ffffff;; 
}

.header-color {
  background-color: var(--easyref-redBg);
  font-weight: bold;
  text-transform: uppercase;
  
}

.header-color a {
  color: white;
}

.header-color a:active {
  color: green !important;
}


.head-div h2  {
 
    text-transform: uppercase;
    font-size: 18px;
    padding: 20px;
    text-align:left;
    background-color: var(--easyref-bg);
    color: white;
    text-transform: uppercase;
    border-radius: 6px;
    margin-bottom: 2px;
    background-image: linear-gradient(var(--easyref-bg),var(--easyref-bg-darken));
}


</style>
