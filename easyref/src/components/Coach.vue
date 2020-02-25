<template>
<div class="container">
  <h1 class="text-center game-header">Tränare</h1>
  
<ul>
    <li v-for="data in coaches" :key="data.id">  
  <div class="row">
    <div class="col-sm">
      <strong>{{ data.firstName }} {{data.lastName}}</strong>
      <p>Förening {{data.compound}}</p>
       <p><i class="fa fa-phone " aria-hidden="true"></i> {{ data.phone }}</p>
       <p><i class="fa fa-envelope " aria-hidden="true"></i> {{data.email}}</p>
     
    </div>
    <!-- <div class="col-sm text-center">
       <h2>{{ data.compound}}</h2>
     
    </div> -->
    
  </div>
</li>
</ul> 
</div>
</template>
<script>

import axios from 'axios';
export default {
 name: 'coach',
  
  props: {
    msg: String
  },
  components: {
   
  },
  data: function() {
    return {
      coaches: [],
    }
  },



mounted() {

axios.get(process.env.VUE_APP_BASE_URL+'/api/coaches').then(res => {
  this.coaches = res.data;
  
console.log(this.coaches)
 
  
});

}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    display: flex;
    flex-wrap: wrap;
     
     
}
ul li {

      margin: 2px;
      padding: 6px 12px;
      background: rgb(238, 238, 238);   
      display: block;
      width: calc(50% - 4px);
}

ul li p {
  margin-bottom: 4px;
}


</style>
