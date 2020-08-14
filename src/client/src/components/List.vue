<template>
  <div class="list">
    <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
      <thead>
          <tr>
              <th>ばんごう</th>
              <th>なまえ</th>
              <th>サムネイル</th>
              <!-- <th>イメージ</th> -->
          </tr>
      </thead>
      <tbody>
          <tr v-for="item in myData" v-bind:key="item.id">
              <td class="table-id"><router-link :to="`About/${item.id}`">{{item.id}}</router-link></td>
              <!-- <td class="table-name"><router-link ：to="{ name:'About/', params: {id: item.id}}">{{item.name.japanese}}</router-link></td> -->
              <td class="table-name"><router-link :to="`About/${item.id}`">{{item.name.japanese}}</router-link></td>
              <td><img v-bind:src="createThumbnailUrl(item)"></td>
              <!-- <td class="table-image"><router-link :to="`About/${item.id}`" v-bind:style="`background-image:${createThumbnailUrl(item)}`"></router-link></td> -->
              <!-- <td><img v-bind:src="createImagelUrl(item)" crossorigin="anonymous" /></td> -->
              <!-- <td><img v-bimd:src="createImagelUrl(item)" crossorigin="anonymous" /></td> -->
          </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
const server = 'http://192.168.2.180:5000/'

import axios from 'axios'
import About from '../views/About'


export default {
  name: 'List',
  data: function(){
      return {
        myData: null,
        error: null
      }
  },
  components: About,
  created: function() {
        axios.get(server + 'pokeapi/')
        .then(response => {
          // for (var i = 0; i < response.data.length; i++){
          //   response.data[i].thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
          //   response.data[i].image = 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
          // }
          this.myData = Array(response.data.length - 1)
          for (var i = 0; i < response.data.length; i++) {
            let item = response.data[i]
            item.thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
            item.image = server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
            this.myData[i] = item
          }
        })
        .error(error => {
          alert(error)
        })
        // fetch('http://localhost:5000/pokeapi/')
        // .then( Response =>{
        //     return Response.json()
        // })
        // .then( json => {
        //     //this.myData = json
        //     this.myData = json;
        // })
        // .catch( error => {
        //     alert(error)
        //     this.error = error
        // });
  },
  methods: {
    createThumbnailUrl: function(item){
      return `https://www.pkparaiso.com/imagenes/shuffle/sprites/${('000' + item.id).slice(-3)}.png`
    },
    createImagelUrl: function(item){
      return server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
    }
  }
}
</script>
<style scoped>
.table tbody td{
  text-align: center;
  vertical-align: middle;
}
.table tbody td.table-id, td.table-name{
  font-size: 1.5em;
}
</style>
