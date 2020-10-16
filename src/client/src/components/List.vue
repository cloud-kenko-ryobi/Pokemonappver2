<template>
  <div class="list">
    <div class="field is-left">
      <label class="label" for="type">タイプ</label>
      <div class="control is-left">
        <div class="select is-rounded is-primary">
        <select name="" id="type" v-on:change="changeType($event)">
          <option value="All">ぜんぶ</option>
          <option value="Normal">ノーマル</option>
          <option value="Fighting">かくとう</option>
          <option value="Flying">ひこう</option>
          <option value="Poison">どく</option>
          <option value="Ground">じめん</option>
          <option value="Rock">いわ</option>
          <option value="Bug">むし</option>
          <option value="Ghost">ゴースト</option>
          <option value="Steel">はがね</option>
          <option value="Fire">ほのお</option>
          <option value="Water">みず</option>
          <option value="Grass">くさ</option>
          <option value="Electric">でんき</option>
          <option value="Psychic">エスパー</option>
          <option value="Ice">こおり</option>
          <option value="Dragon">ドラゴン</option>
          <option value="Dark">あく</option>
          <option value="Fairy">フェアリー</option>
        </select>
        </div>
      </div>
    </div>    
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
              <td class="table-id"><router-link :to="`About/${item.id}`" style="display: inline-block; width:100%; height:100%;">{{item.id}}</router-link></td>
              <!-- <td class="table-name"><router-link ：to="{ name:'About/', params: {id: item.id}}">{{item.name.japanese}}</router-link></td> -->
              <td class="table-name"><router-link :to="`About/${item.id}`" style="display: inline-block; width:100%; height:100%;">{{item.name.japanese}}</router-link></td>
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
const server = 'http://localhost:5000/'

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
        String.prototype.toHiragana = function(){
          return this.replace(/[\u30a1-\u30f6]/g, match => {
            let chr = match.charCodeAt(0) - 0x60;
            return String.fromCharCode(chr);
          })
        }
        axios.get(server + 'pokeapi/')
        .then(response => {
          this.myData = response.data.map(item =>{
            item.thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
            item.image = server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
            item.name.japanese = item.name.japanese.toHiragana()
            return item 
          })
          // this.myData = Array()
          // for (var i = 0; i < response.data.length; i++) {
          //   let item = response.data[i]
          //   item.thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
          //   item.image = server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
          //   item.name.japanese = item.name.japanese.toHiragana()
          //   this.myData[i] = item
          // }
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
    },
    changeType: function(event){
      const type = event.target.value
      
      this.myData = null
      axios.get(server + 'pokeapi/')
      .then(response => {
        this.myData = response.data
                      .filter(item => (type === "All" || item.type.indexOf(type) > -1))
                      .map(item => {
                        item.thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
                        item.image = server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
                        item.name.japanese = item.name.japanese.toHiragana()
                        return item 
                      })
      })
      .error(error => {
        alert(error)
      })
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
