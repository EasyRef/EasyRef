<template>
<form class="form" >
  <div class="container">
    <h1 class="text-center game-header">Skapa ny användare</h1>
    <nav class="">
            <ul class="menu-list">        
                <button class="btn  game-btn">
                    <router-link class="router" to="/Admin">Användare</router-link>
                </button>
                <button class="btn  game-btn">
                    <router-link class="router" to="/AddUser">Ny användare</router-link>
                </button>
                <button class="btn  game-btn">
                    <router-link class="router" to="/ContactInfo">Kontakt Info </router-link>
                </button>
                <button class="btn  game-btn">
                    <router-link class="router" to="/About">Om oss</router-link>
                </button>
            </ul>
        </nav>
    <div class="form-group col-md-7">
          <label class="label" for="id">Förnamn: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Efternamn: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Telefon nummer: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">E-post: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Förening: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Pojkar/flickor: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Ålder: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Dömmer upp till: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Hemma plats/plan: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <label class="label">Lösenord: </label>
          <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <button class="btn game-btn" @click.prevent="Save()">Spara</button>
          <button class="btn game-btn" @click.prevent="Cancel()">Ångra</button>
    </div>
  </div>
</form>
</template>

<script>
 export default {    
     data() {
         return {
             user: {},
            firstname: '',
            lastname: '',
            phone: 0,
            compound: '',
            email: '',
            password: '',
            judgingage: '',
            userdetails: '',
            homeplace: ''
        }
     },

  methods: {
     Save: function () {
        console.log();
        // axios.post(process.env.VUE_APP_BASE_URL+'/api/contactInfo', {

        // HomeTeam: this.game.homeTeam,
        // GameGenderId: this.game.gameGenderId,
        // GameAgeId: this.game.gameAgeId,
        // FieldLocation: this.game.fieldLocation,
        // GameFieldSizeId: this.game.gameFieldSizeId,
        // GameDivisonId: this.game.levelId,
        // CoachId: this.game.coachId
        //.catch({ })      
     },
     Cancel: function() {
         //ladda om sidan med kontaktinfon från db igen
     }
 }   
 }
</script>

<style>
.container {
  align-items: center;
}

.form {
  align-items: center;
  border: white;
  border-width: 3px;
}
.router {
    color: white;
}
</style>