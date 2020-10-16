import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import bulma from 'bulma';
import Axios from 'axios';

function App() {
  // const server = 'http://localhost:5000/'
  // const pokemons
  // Axios.get(server + 'pokeapi/')
  // .then(response => {
  //   pokemons = response.data.map(item => {
  //     item.thumbnail = server + 'assets/thumbnails/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
  //     item.image = server + 'assets/images/' + ('000' + item.id).slice(-3) + item.name.english + '.png'
  //     item.name.japanese = item.name.japanese.toHiragana()
  //     return item 
  //   })
  // })
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
