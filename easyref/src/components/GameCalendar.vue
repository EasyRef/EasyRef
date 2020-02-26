<template>
<div class="container">
  <h1 class="text-center game-header">Kalender</h1>
    <FullCalendar class="calendar-div"
      ref="fullCalendar"
      defaultView="dayGridMonth"
      
      :header="{
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
      }"
      :plugins="calendarPlugins"
      :weekends="calendarWeekends"
      :events="calendarEvents"
      :locales="locales"
      
  
      />
  </div>
</template>
<script>
import axios from 'axios';
import FullCalendar from '@fullcalendar/vue'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'
import svLocale from '@fullcalendar/core/locales/sv';


export default {
 
  name: 'calendar',
  
  props: {
    msg: String
  },
  components: {
    FullCalendar 
  },
  data: function() {
    return {
      calendarPlugins: [
        dayGridPlugin,
        timeGridPlugin
      ],
      calendarWeekends: true,
      locales: [svLocale],
      calendarEvents: [],
      
    }
  },

  method: {
   
  },


mounted() {

axios.get(process.env.VUE_APP_BASE_URL+'/api/games').then(res => {
  
console.log(process.env.VUE_APP_BASE_URL)
  for (let idx = 0; idx < res.data.length; idx++) {
    this.calendarEvents.push({
        id: res.data[idx].gameId,
        start: res.data[idx].startDate,
        end: res.data[idx].endDate,
        title: res.data[idx].homeTeam + " - " + res.data[idx].awayTeam,
    });
  }
  
  
});
// $(".fc-button").css("background","var(--easyref-calFunc)");
 //$(".fc-button").css("color","black");


}
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

@import '~@fullcalendar/core/main.css';
@import '~@fullcalendar/daygrid/main.css';
@import '~@fullcalendar/timegrid/main.css';

.calendar-div {
  background-color: white; 
  border-radius: 12px;
  padding: 10px;
}

h1 {
  border: 1px solid #ffffff;
  padding: 20px;
  text-align: center;
  color: #ffffff;
}

</style>
