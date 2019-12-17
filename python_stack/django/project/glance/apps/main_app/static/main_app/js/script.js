window.addEventListener('load', () => {
  let long;
  let lat;
  let temperatureDescription = document.querySelector(`.tempdesc`);
  let temperatureDegree = document.querySelector(`.degree`);
  let locationTimezone = document.querySelector(`.tz`)

  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(position => {
      long = position.coords.longitude;
      lat = position.coords.latitude;

      const proxy = `https://cors-anywhere.herokuapp.com/`;
      const api = `${proxy}https://api.darksky.net/forecast/5e6dc6053c58a92d9f755f3f1b95c5a3/${lat}, ${long}`;
  
      fetch(api)
        .then(response => {
          return response.json();
        })
        .then(data => {
          const {temperature, summary, icon} = data.currently;
          temperatureDegree.textContent = temperature;
          temperatureDescription.textContent = summary;
          locationTimezone.textContent = data.timezone;
            setIcons(icon, document.querySelector(`.icon`));
        })
    });
  }

  function setIcons(icon, iconID){
    const skycons = new Skycons({color: 'black'});
    const currentIcon = icon.replace(/-/g, "_").toUpperCase();
    skycons.play();
    return skycons.set(iconID, Skycons[currentIcon]);
  }
});