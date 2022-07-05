import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { environment } from '../../environments/environment';
import { Product } from '../models/product.model';

@Injectable()
export class ProductsService {
  constructor(private http: HttpClient) { }

  getProductsList(countryId: string): Observable<any> {
    const getProductsUrl: string = environment.apiBaseUrl + 'products/' + countryId;
    return this.http
      .get(getProductsUrl)
      .pipe(
        map((data: Product[]) =>
          data.map(
            (product: Product) =>
              new Product(
                product.id,
                product.name,
                product.baseUnitPrice,
                product.sellingPrice
              )
          )
        )
      );
  }  
}
