import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/models/city';
import { HistoricalWeather } from 'src/app/models/historicalWeather';
import { CityService } from 'src/app/services/city.service';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  cities: City[];
  selectedCity: string ="";
  addHistorical: boolean = false;
  actualWeatherMap: HistoricalWeather;
  historicalWeather: HistoricalWeather[];
  showMessage: boolean = false;
  constructor(private weatherService: WeatherService, private cityService: CityService) { }

  ngOnInit(): void {
    this.loadCities();
  }

  loadHistoricalWeather() {
    this.weatherService.getHistoricalWeather(+this.selectedCity).subscribe(
      res => this.historicalWeather = res
    );
  }

  loadCities(){
    this.cityService.getCities().subscribe(
      res => this.cities = res
    );
  }

  getActualWeatherMap(){
    if(+this.selectedCity != 0){
      this.showLoadScreen(true);

      this.showMessage = false;
      this.weatherService.getActualWeatherMap(+this.selectedCity).subscribe(
        res => {
          this.actualWeatherMap = res;
          if(this.addHistorical)
            this.loadHistoricalWeather();
          this.showLoadScreen(false);
        });
    }
    else
      this.showMessage = true;
  }
  showLoadScreen(show: boolean) {
    if(show)
      document.getElementById("overlay").style.display = "block";
    else
      document.getElementById("overlay").style.display = "none";
  }

}
