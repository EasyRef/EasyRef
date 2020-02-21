<template>
<div class="container">
  <h2 class="text-center game-header">Kalender</h2>
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
    FullCalendar // make the <FullCalendar> tag available
  },
  data: function() {
    return {
      calendarPlugins: [ // plugins must be defined in the JS
        dayGridPlugin,
        timeGridPlugin
      ],
      calendarWeekends: true,
      locales: [svLocale],
      calendarEvents: [],
      
    }
  },


mounted() {

axios.get(process.env.VUE_APP_BASE_URL+'/api/games').then(res => {
  
console.log(process.env.VUE_APP_BASE_URL)
  for (let idx = 0; idx < res.data.length; idx++) {
    this.calendarEvents.push({
        id: res.data[idx].gameId,
        start: res.data[idx].startDate,
        end: res.data[idx].endDate,
        title: res.data[idx].homeTeam + " - " + res.data[idx].awayTeam
    });
  }
  console.log(this.calendarEvents)
  
});

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

</style>
