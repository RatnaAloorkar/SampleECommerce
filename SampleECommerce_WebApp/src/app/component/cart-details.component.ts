import { SharedInfoService } from '../service/shared-info.service';
import { OrderService } from '../service/order.service';
import * as CartActions from '../stateManagerReduxStore/actions/cart.actions';
import { CartState } from '../stateManagerReduxStore/state/cart.state';
import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Country } from '../models/country.model';
import { Cart } from '../models/cart.model';

@Component({
  selector: 'cart-details',
  templateUrl: './cart-details.component.html',
})
export class CartDetailsComponent {
  private country: Country;
  private shipping: number;
  private subTotal: number;
  private total: number;
  cart: Cart[] = [];
  @Output() changeDisplayEvent = new EventEmitter<boolean>();

  constructor(private store: Store<CartState>, private orderService: OrderService, private sharedInfoService: SharedInfoService, private router: Router) { }
  ngOnInit() {
    this.sharedInfoService.selectedCountry.subscribe((value) => {
      this.country = value;
      if (this.country !== null) {
        this.loadBasketDetails();
      }
    });
  }

  removeProductFromCart(paramProduct: Cart) {
    this.store.dispatch(new CartActions.RemoveFromCart(parseInt(paramProduct.productId)));
  }

  displayProductList() {
    this.changeDisplayEvent.emit(true);
  }

  placeAnOrder() {
    this.store.select('cart').subscribe((data) => {
      const cartData = data;
      cartData.subTotal = this.subTotal;
      this.orderService.orderCheckout(cartData).subscribe((response) => {
        if (response.ok) {
          this.router.navigate(['/order-placed'],{queryParams: {orderNo: response.body }});
        }
      });
    });
  }

  loadBasketDetails() {
    this.store.select('cart').subscribe((data) => {
      this.cart = data.products;
      this.subTotal = data.subTotal;
      this.getShippingPrice();
    });
  }

  getShippingPrice() {
    if(this.subTotal !== 0)
    {
      this.orderService.getShippingPrice(this.subTotal).subscribe(result => {
        this.shipping = result;
        this.total = this.subTotal + this.shipping;
      });
    }
    else{
      this.shipping = 0;
      this.total = 0;
    }
  }
}
