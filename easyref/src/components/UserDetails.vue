<template>
<form class="form" >
  <div class="container">
    <h1 class="text-center game-header">Redigera Användare</h1>
    <li v-for="user in coach" :key="user.coachId">
      <div class="form-group col-md-7">
            <label class="label">Förnamn: </label>
            <input type="text" class="form-control" />
      </div>
      <div class="form-group col-md-7">
            <label class="label">ID: </label>
            <!-- <userId @inputData="updateUser" /> -->
            <input type="text" class="form-control" v-model="coachId"/>
      </div>
      <!-- <div class="field">
                <label class="label" for="id">id</label>
                <label class="input"> {{id}}</label>
              </div> -->
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
            <label class="label">Kön: </label>
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
            <label class="label">Nytt lösenord: </label>
            <input type="text" class="form-control" />
      </div>
      <div class="form-group col-md-7">
            <button class="btn game-btn" @click.prevent="Save()">Spara</button>
            <button class="btn game-btn" @click.prevent="Cancel()">Ångra</button>
      </div>
    </li>
  </div>
</form>
</template>

<script>
import axios from 'axios';
//import coachId from './Admin';

export default {
  
  props: { coachId: {
    type: Number,
    default: 0,
      },
    },
 
      data() {
          return {
              coach: [],
         };
      },
    //  watch: {
    //    id: function() {
    //      this.user.push(this.id);
    //    }
    //  },
         
// mounted() {
//      axios.get(`${process.env.VUE_APP_BASE_URL}/coaches/${0}`);
//  },

  mounted() {
     // const id = Number.parseInt(coachId);

      axios.get(process.env.VUE_APP_BASE_URL + '/api/Coaches/1').then(res => {
        this.coach = res.data
        console.log(res.data)
        });
  },
    // updateUser: function(variable) {
    //     this.user = variable;
    //},
    //  Save: function () {
    //     console.log();
    //     // axios.post(process.env.VUE_APP_BASE_URL+'/api/contactInfo', {
    //     // StartDate: this.game.startDate,
    //     // EndDate: this.game.endDate,
    //     // HomeTeam: this.game.homeTeam,
    //     // GameGenderId: this.game.gameGenderId,
    //     // GameAgeId: this.game.gameAgeId,
    //     // FieldLocation: this.game.fieldLocation,
    //     // GameFieldSizeId: this.game.gameFieldSizeId,
    //     // GameDivisonId: this.game.levelId,
    //     // CoachId: this.game.coachId
    //     //.catch({ })      
    //  },
    //  Cancel: function() {
    //      //ladda om sidan med kontaktinfon från db igen
        
 };  
 
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

</style>