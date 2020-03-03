<template>
<div class="container">
    <h1 class="text-center game-header">Om oss</h1>    
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
    <div class="form-group col-md-12">
        <label class="label">Redigera Om oss: </label>
        <input type="text" class="form-control" />
    </div>
    <div class="form-group col-md-7">
          <button class="btn game-btn"  @click.prevent="Save()">Spara</button>
          <button class="btn game-btn"  @click.prevent="Cancel()">Ångra</button>
    </div>
    </div>
    
</template>

<script>
export default {
 methods: {
     Save: function () {
        console.log();
        // axios.post(process.env.VUE_APP_BASE_URL+'/api/contactInfo', {
        // ContactInfo: this.contactInfo}).catch}).catch({ })      
     },
     Cancel: function() {
         //ladda om sidan med kontaktinfon från db igen
     }
 }   
}
</script>

<style scoped>
.router {
    color: white;
    font-size: 3px
}
</style>