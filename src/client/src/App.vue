<template>
  <div id="app">
    <div id="nav">
      <!-- <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link> -->
      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
            <tr>
                <th>ID</th>
                <th>なまえ</th>
                <th>サムネイル</th>
                <th>イメージ</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in myData" v-bind:key="item.id">
                <td class="table-id">{{item.id}}</td>
                <td class="table-name">{{item.name.japanese}}</td>
                <td><img v-bind:src="createThumbnailUrl(item)" crossorigin="anonymous"/></td>
                <td><img v-bind:src="createImagelUrl(item)" crossorigin="anonymous" /></td>
                <!-- <td><img v-bimd:src="createImagelUrl(item)" crossorigin="anonymous" /></td> -->
            </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
const server = 'http://localhost:5000/'

import axios from "axios"

export default {
  name: "app",
  data: function(){
      return {
        myData: null,
        error: null
      }
  },
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
<style lang="scss">
@import "../node_modules/bulma/bulma.sass";
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

.table tbody td{
  text-align: center;
  vertical-align: middle;
}
.table tbody td.table-id, td.table-name{
  font-size: 1.5em;
}
</style>
