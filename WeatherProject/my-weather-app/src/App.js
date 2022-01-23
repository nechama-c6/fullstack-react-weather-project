import React, { useState, useEffect } from "react";
import './App.css';
import Search from './components/search';
import Weather from './components/weather';

export function App() {
  const [favorites, setFavorites] = useState([]);
  const [weatherData, setWeatherData] = useState([]);

  useEffect(async () => {
    var res = await fetch(`${process.env.REACT_APP_FAVORITES_API_URL}`);
    var data = await res.json();
    setFavorites(data);
  }, []);


  async function addFavorite(favoriteCityKey) {
    try {
      if (favoriteCityKey != '') {
        if (!favorites.some(alreadyFavorite => alreadyFavorite.cityKey == favoriteCityKey)) {
          await fetch(`${process.env.REACT_APP_FAVORITES_API_URL}`, {
            method: 'post',
            body: JSON.stringify(favoriteCityKey),
          });
          setFavorites([...favorites, { cityKey: favoriteCityKey }]);
        }
        else
          alert('city already in favorites!');
      }
    }
    catch (error) {
      console.log(error);
    }
  };

  async function getCurrentCondition(cityKey) {
    let response = await fetch(`${process.env.REACT_APP_WEATHER_CONDITION_API_URL}${cityKey}?apikey=${process.env.REACT_APP_WEATHER_API_KEY}`);
    let data = await response.json()
    setWeatherData(data[0]);
  }


  return (
    <div className="App">
      <p>You have {favorites.length}  favorite cities </p>
      <Search citySelected={getCurrentCondition} addFavorite={addFavorite} />
      {(typeof weatherData.Temperature != 'undefined') ? (
        <Weather  weatherData={weatherData} />
      ) : (
        <div></div>
      )}
    </div>
  );
}

export default App;
