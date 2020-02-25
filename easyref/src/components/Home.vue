
<template>

<div class="container">
 
  <h1 class="text-center game-header">Välkommen!</h1>
  <div class="news-div">
    <h2>Fakenews</h2>

    <ul>
      <li v-for="data in news" :key="data.key">
        <div class="row">
    <div class="col-sm">
        <strong>{{data.title}}</strong>
    </div>
    <div class="col-sm text-right">
        <em> {{data.author}} ({{data.published}})</em>
    </div>
    </div>
     <div class="row">
    <div class="col-sm">
        <hr>
        {{data.news}}
    </div>
    </div>
        </li>
      </ul>
</div>
    </div>
    

</template>
<script>

export default {
  name: 'Home',
  props: {
    msg: String
  },
  data() {
    return {
      news: [{
        title: 'Framtiden ser ljus ut..',
        news: 'Nu när våren börjar närma sig anar man duvornas frammarsch, detta i sig kan bero på den ordentliga luftfuktighet som uppstod då Borlänge energi släppte ut 5 ton svaveldioxid',
        author: 'Bertil Enstöring',
        published: '2020-03-14',
      },{
        title: 'Sogeti manglar konkurenterna...',
        news: 'Återigen stoltserar sig Sogeti som överlägsna vinnare av Kalle Anka cup på domnarsvallen.'
         +'Rimsky stod för årets utvisning då han glidtacklade den egna lagkamraten Martin Olsen ut ur Arenan. Detta tack vare en stark nordöstlig bris som precis passerade och drog iväg Martin långt ut över Dalälven vidare mot klubbhuset på Aspeboda GK '
         +'där han sedan blev väl omhändertagen av ett äldre par från Hälsingland. Dagen avslutades med 18 hål och slutligen en middag där det samtalades om allt från himmel till jord.',
        author: 'Tabue',
        published: '2020-03-17',
      },{
        title: 'Erik Karlsson dominerar...',
        news: 'Då var det återigen dags att utse årets framgångsrikaste dalmas. Erik Karlsson heter han och stämmer fiolen med ett brett leende',
        author: 'Tabue',
        published: '2020-03-17',
      },
      ],
   
    }
  },
 mounted() {
   
  }

}
</script>


<style scoped>
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
       
        margin-top: 6px;
        display: flex;
        flex-direction: column;
        
       
}
.news-div h2 {
 
    text-transform: uppercase;
    font-size: 18px;
    padding: 20px;
    text-align:left;
    background-color: #092c52;
    color: white;
    text-transform: uppercase;
    border-radius: 6px;
    margin-bottom: 2px;
    background-image: linear-gradient(#0e3f75,#092c52);
}
</style>
