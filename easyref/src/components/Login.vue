<template>
  
        <div class="login-container">
      
      

<div style="background: white; padding: 20px;">
        <form  >
      <div class="form-row">
          <div class="img-wrapper">
           <img width="45%" src="../assets/Logga.jpg">
           <hr>
           </div>
           
      <div class="form-group col-md-12">
        <label for="user">Epost</label>
        <input type="text" class="form-control" id="user" v-model="login.username" required >
      </div>
      </div>
       <div class="form-row">
      <div class="form-group col-md-12">
        <label for="password">Lösenord</label> <em style="font-size: 14px; float: right;"><a href="">Glömt lösendord?</a></em>
        <input type="text" class="form-control" id="password" v-model="login.password" required >
      </div>
      </div>

  <div class="form-check">
    
  </div>
      <button @click.prevent="login()" class="btn login-btn col-md-12" >Logga in</button>
      
      <hr>
      <a href="" class="text-center">Skapa konto</a>

    </form>
    </div>
    </div>
      
</template>

<script>


export default {
    name: 'login',
    data: function() {
        return {

         
            login: {
                username: '',
                passwornd: ''
            },

        }
    },

    computed: {

    }

    }

</script>

<style scoped>


.login-container {
    position: relative;
    left: 0;
    right: 0;
    top: 100px;
    bottom: 0px;
    margin: auto;
    padding-top: 80px;
    padding-bottom: 40px;
    background-color: var(--easyref-red);
    width: 300px;
     border: 1px solid #ffffff;
     border-radius: 6px;
     font-size: 14px;
     
   
  
   
}

.login-btn {
    background-color:  var(--easyref-red);
    border: 1px solid #ffffff !important;
    color: white !important;
}
.login-btn:hover {
    background-color: var(--easyref-bg-darken) !important;
}

.login-container h3 {
    background: #092c52;
    color: #ffffff;
    text-transform: uppercase;
    font-size: 14px;
    padding: 20px;
    text-align: center;
}

.img-wrapper {
text-align: center;
padding: 6px 12px;
}

input[type=text] {
  height: 30px;
  font-size: 12px;
}

</style>