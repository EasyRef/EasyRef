
 <template>
<div>
  <h2 class="text-center game-header">Matcher</h2>
<ul>
    <li v-for="data in games" :key="data.id">  
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
      <p>Första domare <span class="ref-status status-taken"></span></p>
      <p>2<span class="ref-status status-available"></span></p>
      <p>3<span class="ref-status"></span></p>
    </div>
  </div>
</li>
</ul> 
</div>
</template>

<script>
import axios from 'axios';
import moment from 'moment';
import 'moment/locale/sv' 
export default {
 name: 'games',
  
  props: {
    msg: String
  },
  components: {
   
  },
  data: function() {
    return {
      games: []
    }
  },
  methods: {

  },

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
  }

},


mounted() {

axios.get(process.env.VUE_APP_BASE_URL+'/api/games').then(res => {
  this.games = res.data
console.log(this.games)
console.log(this.games[0] +" " +moment(this.games[0].startDate).format('MM/DD/YYYY hh:mm') )
 
  
});

}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped >

.ref-status {
  width: 25px; 
  height: 12px;
  margin: 0 auto;
   display: inline-block;
    border: 1px solid gray; 
    vertical-align: middle; 
    border-radius: 2px; 
    background: #e02619
}

.status-taken {
 background: #e02619
}
 .status-available {
background: #3bcc12;
}

ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    display: flex;
    flex-wrap: wrap;
}
ul li {
 background: rgb(238, 238, 238);
        padding: 1em;
        width: 100%;
       
        margin-top: 2px;
        display: flex;
        flex-direction: column;
}

ul:hover {

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
