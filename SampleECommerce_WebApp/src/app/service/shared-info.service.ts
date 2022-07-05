import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Country } from '../models/country.model';

@Injectable()
export class SharedInfoService {

  private country = new BehaviorSubject<Country>(null);
  get selectedCountry() {
    return this.country.asObservable();
  }
  setCountry(Country: Country) {
    this.country.next(Country);
  }
}
