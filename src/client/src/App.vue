<template>
  <div id="app">
    <div id="nav">
      <!-- <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link> -->
      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
            <tr>
                <th>ID</th>
                <th>名前</th>
                <th>サムネイル</th>
                <th>え</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="item in myData" v-bind:key="item.id">
                <td>{{item.id}}</td>
                <td>{{item.name.japanese}}</td>
                <td>{{item.base.HP}}</td>
                <td>{{item.base.Attack}}</td>
            </tr>
        </tbody>
      </table>      
    </div>
  </div>
</template>]

<script>
import axios from  "axios"

export default {
  name: "app",
  data: function(){
      return {
        myData: null,
        error: null
      }
  },
  created: function() {
        axios.get('http://localhost:5000/pokeapi/')
        .then(response => {
          this.myData = response
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
</style>
