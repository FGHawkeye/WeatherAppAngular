import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { HistoricalWeather } from '../models/HistoricalWeather';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  url: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getActualWeatherMap(cityId: number, addHistorical: boolean): Observable<HistoricalWeather>{
    return this.http.get<HistoricalWeather>(`${this.url}/weathermap/GetActualWeatherMap?cityId=${cityId}&addHistorical=${addHistorical}`);
  }
}
