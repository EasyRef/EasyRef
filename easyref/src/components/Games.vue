
 <template>
<div class="container">
  <h1 class="text-center game-header">Matcher</h1>


  <div class="games-list-div" v-for="data in games" :key="data.id">

 <div class="row month-row" v-if="checkMonth(data.startDate)">
        <div class="col-sm text-center">
         <h2>{{data.startDate | checkCurrentMonth}} </h2>
     
      </div>
      </div>
     

    <div class="row game-list">
    <div class="col-sm">
      <span class="capitalize-game">{{ data.startDate | date}}</span>
       <p>{{ data.homeTeam }} - {{data.awayTeam}} </p>
        <em v-if="data.gameGender.gender == 'H' || data.gameGender.gender == 'P'"><i class="fa fa-male" aria-hidden="true"></i></em>
       <em v-else><i class="fa fa-female" aria-hidden="true"></i></em>
       <em>{{ data.gameGender.gender}}{{data.gameAge.age}} </em>
       <em>{{ data.gameFieldSize.fieldSize}}-man </em>
      
    </div>
    <div class="col-sm text-center">
     
       <h2>{{ data.startDate | time}}</h2>
       <em>{{ data.fieldLocation}}</em>
      
    </div>
    <div class="col-sm text-right ref-badge">
      <div class="badge-wrapper">

      <!-- EXEMPEL 1-->

      <p><i class="fa fa-user " aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i>
       <span v-if="data.referee" class="ref-status status-taken" ></span>
       <span v-else class="ref-status status-available" v-on:click="addReferee(data)"></span></p>
      <p><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i>
      <span v-if="data.secondReferee" class="ref-status status-taken" ></span>
      <span v-else class="ref-status status-available" v-on:click="addReferee(data)"></span>
      </p>
      <p><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user" aria-hidden="true"></i>
      <span v-if="data.thirdReferee" class="ref-status status-taken"></span>
      <span v-else class="ref-status status-available" v-on:click="addReferee(data)"></span></p>
</div>
      <!-- EXEMPEL 2-->

      <!-- <p style="font-size: 2em;">
        <i v-if="data.referee" class="fa fa-user" style="color:#e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>

          <i v-if="data.secondReferee" class="fa fa-user " style="color: #e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>

          <i v-if="data.thirdReferee" class="fa fa-user " style="color:#e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>      
      </p> -->
     
    </div>
  </div>
      </div>
     
 
 <!-- IGNORERA, LISTA ISTÄLLET FÖR DIV -->
<ul v-show="false">
    <li v-for="data in games" :key="data.id">  
      <div class="row month-row" v-if="checkMonth(data.startDate)">
        <div class="col-sm text-center">
         <h2>{{data.startDate | checkCurrentMonth}} </h2>
     
      </div>
      </div>
     
  <div class="row">
    <div class="col-sm">
      <span class="capitalize-game">{{ data.startDate | date}}</span>
       <p>{{ data.homeTeam }} - {{data.awayTeam}} </p>
        <em v-if="data.gameGender.gender == 'H' || data.gameGender.gender == 'P'"><i class="fa fa-male" aria-hidden="true"></i></em>
       <em v-else><i class="fa fa-female" aria-hidden="true"></i></em>
       <em>{{ data.gameGender.gender}}{{data.gameAge.age}} </em>
       <em>{{ data.gameFieldSize.fieldSize}}-man </em>
      
    </div>
    <div class="col-sm text-center">
     
       <h2>{{ data.startDate | time}}</h2>
       <em>{{ data.fieldLocation}}</em>
      
    </div>
    <div class="col-sm text-right ref-badge">
      <!-- EXEMPEL 1-->
      <!-- <div class="badge-wrapper">
      

      <p><i class="fa fa-user " aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i>
       <span v-if="data.referee" class="ref-status status-taken"></span>
       <span v-else class="ref-status status-available"></span></p>
      <p><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i>
      <span v-if="data.secondReferee" class="ref-status status-taken"></span>
      <span v-else class="ref-status status-available"></span>
      </p>
      <p><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user disabled-ref" aria-hidden="true"></i><i class="fa fa-user" aria-hidden="true"></i>
      <span v-if="data.thirdReferee" class="ref-status status-taken"></span>
      <span v-else class="ref-status status-available"></span></p>

      </div> -->

      <!-- EXEMPEL 2-->

      <p style="font-size: 2em;">
        <i v-if="data.referee" class="fa fa-user" style="color:#e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>

          <i v-if="data.secondReferee" class="fa fa-user " style="color: #e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>

          <i v-if="data.thirdReferee" class="fa fa-user " style="color:#e02619;" aria-hidden="true"></i>
        <i v-else class="fa fa-user" style="color: #3bcc12;;" aria-hidden="true"></i>      
      </p>
     
    </div>
  </div>
</li>
</ul> 

</div>
</template>

<script>
//Import Axios för API anropr, Moment för datetime formatering.
import axios from 'axios';
import moment from 'moment';
import 'moment/locale/sv' 
export default {
 name: 'games',
 month: '',
 active: false,
  
  props: {
    msg: String
  },
  components: {
   
  },
  data() {
    return {
      games: [],
      currentMonth: {
        active: false,
        month: String
      },
    }
  },
  methods: {

    checkMonth: function(month) {
    
      var months = this.$options.filters.checkCurrentMonth(month);

      if(month)
      if(this.$options.month !== months) {
        this.$options.month = months;
        this.$options.active = true;

        return true;
      }
      else {
        this.$options.active = false;
        return false;
      }   
    },

    addReferee: function(value) {
      alert("MatchID: "+value.gameId);
    }
  },

computed: {

},

//Olika filters för att formatera data under rendering. 
filters: {

  date: function(value) {
    if(value) {
      var retDate = moment(value).format('ddd D MMMM');
      return retDate
    }
  },
  time: function(value) {
    if(value) {
      var retTime = moment(value).format('LT');
      return retTime
    }
  },

  checkCurrentMonth: function(month) {
    if(month) {
      var currMonth = moment(month).format('MMMM');
      return  currMonth
    }
  }
},

mounted() {
axios.get(process.env.VUE_APP_BASE_URL+'/api/games').then(res => {
  this.games = res.data
console.log(this.games)
console.log(this.games[0] +" " +moment(this.games[0].startDate).format('MM/DD/YYYY hh:mm') )
 
  
}).catch({



});

}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped >

.game-list {
  background-color: #ededed;
  margin-bottom: 2px;
}

.ref-status {
  width: 25px; 
  height: 12px;
 margin-top: 6px;
 margin-left: 6px;
   display: inline-block;
    border: 1px solid gray; 
    vertical-align: middle; 
    border-radius: 2px; 
    background: #e02619;
    cursor: pointer;
}

.badge-wrapper {
  
  line-height: 2px;

}

.row {
  margin-right: 0px;
  margin-left: 0px;
}
.disabled-ref {
  color: #d4d1cb;
}
.status-taken {
 background: #e02619
}
 .status-available {
background: #3bcc12;
}

.month-row {
    background-color: #092c52;
    color: white;
    text-transform: uppercase;
    margin-bottom: 2px;
    background-image: linear-gradient(#0e3f75,#092c52);
   
}

ul li .month-row {
  border-bottom: 2px solid #092c52;
  margin-bottom: 12px;
  padding: 12px;
  text-transform: uppercase;
  font-weight: bold;

 
} 

.games-list-div {
   background: #ededed;
        
        width: 100%;
       background-color: #092c52;
        margin-top: 1px;
        display: flex;
        flex-direction: column;

        
}
.game-list:hover {
   border-left: 10px solid black;
 
    background: #ffffff;
}

.game-list {
  align-items: center;
}

.game-list p {
  margin-top: 4px;
}




ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    display: flex;
    flex-wrap: wrap;
}
ul li {
 background: #ededed;
        padding: 1em;
        width: 100%;
       
        margin-top: 2px;
        display: flex;
        flex-direction: column;
}

ul li:hover {
    border-left: 10px solid black;
 
    background: #ffffff;
}

ul li p i {
  cursor: pointer;
  margin: 0 auto;
}



.first-ref {
  color: #000000;
}

.second-ref {
  color: #5e5e5e;
}

.ref-status {
  
  float: right;
}

ul li p {
margin: 0;
}

.ref-badge {
  width: 40px;
}
  
.capitalize-game {
  text-transform: capitalize;
  font-weight: bold;
}  

</style>
