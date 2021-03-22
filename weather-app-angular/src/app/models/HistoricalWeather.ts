import { DecimalPipe } from "@angular/common";
import { City } from "./city";
import { Country } from "./country";

export class HistoricalWeather{
    country: Country;
    city: City;
    temperature: number;
    thermalSensation: number;
}