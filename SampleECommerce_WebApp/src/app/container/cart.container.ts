import { Component } from '@angular/core';
@Component({
  selector: 'cart-container',
  templateUrl: './cart.container.html',
})
export class CartContainer {
  showProductList: boolean;
  
  constructor() {
    this.showProductList = true;
  }

  onComponentSwitch(visible: boolean) {
    this.showProductList = visible;
  }
}