import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { environment } from '../../environments/environment';
import { Country } from '../models/country.model';

@Injectable()
export class CountriesService {
  constructor(private http: HttpClient) { }

  getCountriesList(): Observable<Country[]> {
    const getCountriesUrl: string = environment.apiBaseUrl + 'countries';
    return this.http
      .get(getCountriesUrl)
      .pipe(
        map((data: Country[]) =>
          data.map(
            (country: Country) =>
              new Country(
                country.id,
                country.name,
                country.currencyCode,
                country.exchangeRate
                
              )
          )
        )
    );
 }
}
