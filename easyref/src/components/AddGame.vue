
<template>

<div class="add-game-div">
<h2>Lägg up match</h2>

<div style="background: white; margin-top: -2px;">
    
    <form  >
      <div class="form-row">
      <div class="form-group col-md-6">
        <label for="homeTeam">Hemmalag</label>
        <input type="text" class="form-control" id="homeTeam" v-model="game.homeTeam" required >
      </div>

      <div class="form-group col-md-6">
        <label for="awayTeam">Bortalag</label>
        <input type="text" class="form-control" id="awayTeam" v-model="game.awayTeam" >
      </div>
    </div>
<div class="form-row">
    <div class="form-group col-md-12">
      <label for="startDate">Matchstart</label>
      <input type="datetime-local" class="form-control" id="startDate" v-model="game.startDate" required >
    </div>

    <div class="form-group col-md-12">
      <label for="endDate">Slut</label>
      <input type="datetime-local" class="form-control" id="endDate" v-model="game.endDate" >
    </div>
  </div>
 

<div class="form-row">
  <div class="form-group col-md-8">
    <label for="fieldLocation">Plats</label>
    <input type="text" class="form-control" id="fieldLocation" v-model="game.fieldLocation" >
  </div>
  <div class="form-group col-md-4">
    <label for="fieldSize">Plan</label>
    <select class="form-control" id="fieldSize" name="fieldSizeId" v-model="game.gameFieldSizeId">
         <option v-for="data in fieldSize" :key="data.id" v-bind:value="data.id">{{data.fieldSize}}</option>
    </select>

  </div>
  
 
</div>

<div class="form-row">
  
  <div class="form-group col-md-4">
    <label for="gameGenderId">Kön</label>
    <select class="form-control" id="gameGenderId" name="gameGenderId" v-model="game.gameGenderId" >
        <option v-for="data in genders" :key="data.id" v-bind:value="data.id">{{data.gender}}</option>
  </select>
  </div>
  
  <div class="form-group col-md-4">
    <label for="gameAgeId">Ålder</label>
    <select class="form-control" id="gameAgeId" name="gameAgeId" v-model="game.gameAgeId"  >
       <option v-for="data in ages" :key="data.id" v-bind:value="data.id">{{data.age}}</option>
       
  </select>
  </div>
 
  <div class="form-group col-md-4">
    <label for="level">Division</label>
   <select class="form-control" id="level" name="levelId" v-model="game.gameDivisionId"  >
       <option v-for="data in division" :key="data.id" v-bind:value="data.id">{{data.division}}</option>
       
  </select>
  </div>
  </div>
     <div class="form-row">
    

      <div class="form-group col-md-12">
        <label for="coach">Tränare</label>
       <select class="form-control" id="coach" name="coach" v-model="game.coachId" >
         <option selected disabled class="text-hide">Title</option>
        <option v-for="data in coaches" :key="data.id" v-bind:value="data.coachId">{{data.firstName}} - {{data.lastName}} {{data.compound}}</option>
       </select>
      </div>
  </div>
 <hr>

      <button @click.prevent="addGame()" class="btn  game-btn col-md-12" >Lägg upp match</button>

    </form>
    </div>
   
    </div>
    

</template>
<script>
import axios from 'axios';
export default {
    //statiska variabler, som kan ändrar under rendering
  name: 'AddGame',
  props: {
    msg: String
  },

  //Instantiserar reaktiva variabler
  data() {
    return {
     
      game: {
        homeTeam:'',
        awayTeam: '',
        startDate: '',
        endDate: '',
        gameGenderId: 0,
        gameAgeId: 0,
        fieldLocation: '',
        gameFieldSizeId: 0,
        gameDivisionId: 0,
        coachId: 0
      },
      fieldSize: [],
      division: [],
      genders: [],
      ages: [],
      coaches: []
    }
  },
 mounted() {
    console.log("Start");

    axios.get(process.env.VUE_APP_BASE_URL+'/api/gamedivisions').then(res => {
      this.division = res.data
      console.log(this.division)
    }).catch({
        
    });

     axios.get(process.env.VUE_APP_BASE_URL+'/api/gamefieldsizes').then(res => {
       this.fieldSize = res.data;
      console.log(this.fieldSize)
    }).catch({

    });

     axios.get(process.env.VUE_APP_BASE_URL+'/api/gamegenders').then(res => {
     this.genders = res.data;
     console.log(this.genders);
    }).catch({

    });

     axios.get(process.env.VUE_APP_BASE_URL+'/api/gameages').then(res => {
       this.ages= res.data;
       console.log(this.ages)

    }).catch({

    });
     axios.get(process.env.VUE_APP_BASE_URL+'/api/coaches').then(res => {
       this.coaches= res.data;
       console.log(this.coaches)

    }).catch({

    });
  },
  methods: {
    addGame: function () {
      console.log(this.game);
      axios.post(process.env.VUE_APP_BASE_URL+'/api/games', {
        StartDate: this.game.startDate,
        EndDate: this.game.endDate,
        HomeTeam: this.game.homeTeam,
        AwayTeam: this.game.awayTeam,
        GameGenderId: this.game.gameGenderId,
        GameAgeId: this.game.gameAgeId,
        FieldLocation: this.game.fieldLocation,
        GameFieldSizeId: this.game.gameFieldSizeId,
        GameDivisonId: this.game.levelId,
        CoachId: this.game.coachId
      }).catch({

      })
    }
  },
 
}


</script>



<style scoped>

.add-game-div {
    position: fixed;
    right: 16px;
    top: 80px;
    width: 300px;
   
     border: 1px solid #ffffff;; 
     border-radius: 2px;  
     background: var(--easyref-redBg);
     
}
.add-game-div h2 {
    background: var(--easyref-redBg);
    color: #ffffff;
    text-transform: uppercase;
    font-size: 14px;
    padding: 20px;
     margin-top: 0.5em;
  margin-bottom: 0.5em;
    text-align: center;
   
}
input[type=button] {
  background-color:var(--easyref-red);
}
input[type=text] {
  height: 30px;
  font-size: 12px;
}
input[type=datetime-local] {
  height: 30px;
  font-size: 12px;
}

select {
    height: 30px;
    font-size: 12px;
}



.add-game-div form {
    padding: 20px;
} 

label {
  font-size: 12px;
}

</style>
