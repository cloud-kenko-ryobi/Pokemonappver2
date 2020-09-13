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
        <h1 class="title">{{ this.item.name.japanese.toHirogana() }}</h1>
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
                <td>{{ this.item.type.join("、") }}</td>
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
const server = 'http://localhost:5000/'

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
    String.prototype.toHirogana = function(){
      return this.replace(/[\u30a1-\u30f6]/g, match => {
        const chr = match.charCodeAt(0) - 0x60
        return String.fromCharCode(chr)
      })
    }
    axios.get(server + 'pokeapi/' + this.$route.params.id)
    .then(response => {
      this.item = response.data;
      const text = this.item.name.japanese.toHirogana() + ". " + this.item.type.join() + 'タイプ'
      const uttr = new SpeechSynthesisUtterance(text)
      var voice = speechSynthesis.getVoices().find(voice => voice.name === 'Google 日本語')
      // 取得できた場合のみ適用する
      if (voice){
        uttr.voice = voice;
      }
      speechSynthesis.speak(uttr)
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