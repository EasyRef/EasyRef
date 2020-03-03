<template>
    <div class="container">    
        <h1 class="text-center game-header">Användare</h1>
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
        <ul>                           
            <li v-for="user in coaches" :key="user.id">                                
                <div class="row" >                                    
                    <div class="col-sm" :style="left">
                        <strong>{{ user.firstName }} {{user.lastName}}</strong>
                        <p>Förening: {{user.compound}}</p>
                        <p><i class="fa fa-phone " aria-hidden="true"></i> {{ user.phone }}</p>
                        <p><i class="fa fa-envelope " aria-hidden="true"></i> {{user.email}}</p>
                        <!-- <p><i class="fa fa-envelope " aria-hidden="true"></i> {{user.coachId}}</p> -->
                    </div>
                </div>
               <button class="btn game-btn" @click="showUserDetail(user)"> 
                     <router-link :to="{ name: 'UserDetails',  params: { coachId: user.coachId} }">                   
                    </router-link> Redigera  
                </button> 
             <!--   <button class="btn game-btn" @click="deleteUser(user)"> Ta bort </button> -->                                                            -->
            </li>
        </ul>
        <!-- <user-id :username='user.username' /> -->
    </div>       
</template>

<script>
import axios from 'axios';
//import UserDetails from "./UserDetails";

export default {
    //name: id ,
    //components: {
        //UserDetails
    //},
     data() {
         return {
             user: {
                 coachId: this.coachId
             },
             coaches: [],         
         };
     },
     
      methods: {
          showUserDetail(user) {
              const id = Number.parseInt(user.coachId);
              this.$router.push('UserDetails/'+ id );
    //          //this.$emit("inputData", this.coaches.id);
          },
      },

    //     deleteUser(user) {
    //         try {
    //             axios.delete(`${process.env.VUE_APP_BASE_URL}/api/user/${user.id}`);
    //             //parseItem(response, 200);
    //             return user.id;
    //         } 
    //         catch (error) {
    //             console.error(error);
    //             return null;
    //         }
    //     }
    // },
    mounted() {
    axios.get(process.env.VUE_APP_BASE_URL+'/api/coaches').then(res => {
        this.coaches = res.data
        console.log(this.coaches)
    });
},
};
</script>

<style scoped>
.left {
    position: relative;
    margin-bottom: 4px;
}
.right {
    position: relative;
    border-left: none;
    margin-bottom: 4px;
}
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
      background: var(--easyref-white);   
      display: block;
      width: calc(50% - 4px);
}

ul li p {
  margin-bottom: 4px;
}

.btn {
    color: black;
    background-color: lightyellow;   
    border-color: black;
}

.menu-list {
    margin: 8px;
    background-color: transparent;
    font-size: 20px;
    font-weight: 500;
    text-align: center;
    size:20px;
}

.router {
    color: white;
}
</style>