import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/models/City';
import { HistoricalWeather } from 'src/app/models/HistoricalWeather';
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
  constructor(private weatherService: WeatherService, private cityService: CityService) { }

  ngOnInit(): void {
    this.loadCities();
    /*this.weatherService.getActualWeatherMap().subscribe(
      res => console.log(res)
    );*/
  }

  loadCities(){
    this.cityService.getCities().subscribe(
      res => this.cities = res
    );
  }

  getActualWeatherMap(){
    this.weatherService.getActualWeatherMap(+this.selectedCity, this.addHistorical).subscribe(
      res => this.actualWeatherMap = res
    );
  }

}
