import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ICart } from '../models/cart.model';

@Injectable()
export class OrderService {
  constructor(private http: HttpClient) { }

  orderCheckout(cart: ICart){
    const checkoutUrl: string = environment.apiBaseUrl + 'orders/checkout';
    return this.http.post(checkoutUrl, cart, {observe: "response" });
  }
  getShippingPrice(subTotal: number): Observable<any> {
    const shippingCostUrl: string = environment.apiBaseUrl + 'orders/shippingprice/' + subTotal.toString();
    return this.http.get(shippingCostUrl);
  } 
}
