<template>
  <p>Refe works</p>
</template>
<script>
import axios from 'axios';



export default {
 
  name: 'referee',
  
  props: {
    msg: String
  },
  components: {
   
  },
  data: function() {
    return {
    }
  },


mounted() {

axios.get(process.env.VUE_APP_BASE_URL+'/api/referees').then(res => {
  
console.log(res)
 
  
});

}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>


</style>
