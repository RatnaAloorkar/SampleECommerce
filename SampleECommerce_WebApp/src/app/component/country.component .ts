import { Component } from '@angular/core';
import { CountriesService } from '../service/countries.service';
import { SharedInfoService } from '../service/shared-info.service';
import { Country } from '../models/country.model';

@Component({
  selector: 'country',
  templateUrl: 'country.component.html'
})
export class CountryComponent {
  countriesList: Country[];
  selectedCountry: Country;

  constructor(private countriesService: CountriesService, private sharedInfoService: SharedInfoService) { }
  
  ngOnInit() {
    this.FillCountries();
  }

  onCountryChange(selectedValue: Country) {
    this.sharedInfoService.setCountry(selectedValue);
  }

  private FillCountries() {
    this.countriesService.getCountriesList().subscribe((Countries: Country[]) => {
      this.countriesList = Countries;
      this.selectedCountry = this.countriesList[0];
      this.sharedInfoService.setCountry(this.selectedCountry);
    });
  }
} 
