<template>
  <div class="about">
    <header class="header">
      <nav>
        <div class="level-right">
          <router-link to="/" class="button is-primary is-large">戻る</router-link>
        </div>
      </nav>
    </header>
    <section class="section">
      <div class="container">
        <h1 class="title">{{ this.item.name.japanese }}</h1>
        <img v-bind:src="createImagelUrl(item)" crossorigin="anonymous" />
        <div class="table-contaner">
          <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
            <tbody>
              <tr>
                <th>No</th>
                <td>{{ this.item.id }}</td>
              </tr>
              <tr>
                <th>タイプ</th>
                <td>{{ this.item.type.join() }}</td>
              </tr>
              <tr>
                <th>HP</th>
                <td>{{ this.item.base.hp }}</td>
              </tr>
              <tr>
                <th>こうげき力</th>
                <td>{{ this.item.base.attack }}</td>
              </tr>
              <tr>
                <th>ぼうぎょ力</th>
                <td>{{ this.item.base.deffence }}</td>
              </tr>
              <tr>
                <th>スピード</th>
                <td>{{ this.item.base.speed }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
const server = 'http://192.168.2.180:5000/'

import axios from "axios"
import Home from "../views/Home"

export default {
  name: 'About',
  data: function(){
    return {
      id: 0,
      item: null
    }
  },
  components: Home,
  created: function(){
        axios.get(server + 'pokeapi/' + this.$route.params.id)
        .then(response => {
          this.item = response.data;
        })
        .error(error => {
          alert(error)
        })
  },
  methods: {
    createImagelUrl: function(item){
      return server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
    }
  }
}
</script>