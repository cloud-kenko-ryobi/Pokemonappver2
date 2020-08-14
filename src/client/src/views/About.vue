<template>
  <div class="about">
    <img v-bind:src="createImagelUrl(item)" crossorigin="anonymous" />
    <h1>{{ this.item.name.japanese }}</h1>
    <h2>{{ this.$route.params.id }}</h2>
    <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
      <tbody>
        <tr>
          <th>No</th>
          <td>{{ this.item.id }}</td>
        </tr>
        <tr>
          <th>タイプ</th>
          <td>{{ this.item.type[0] }}</td>
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
</template>

<script>
const server = 'http://localhost:5000/'

import axios from "axios"

export default {
  name: 'About',
  data: function(){
    return {
      id: 0,
      item: null
    }
  },
  created: function(){
        axios.get(server + 'pokeapi/' + this.$route.params.id)
        .then(response => {
          this.item = response.data[0];
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