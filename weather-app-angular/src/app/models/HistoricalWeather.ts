import { DecimalPipe } from "@angular/common";
import { City } from "./City";
import { Country } from "./Country";

export class HistoricalWeather{
    country: Country;
    city: City;
    temperature: number;
    thermalSensation: number;
}