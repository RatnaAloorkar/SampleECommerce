import { Component, EventEmitter, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { Country } from '../models/country.model';
import { Product } from '../models/product.model';
import { Cart } from '../models/cart.model';
import { SharedInfoService } from '../service/shared-info.service';
import { ProductsService } from '../service/products.service';
import * as CartActions from '../stateManagerReduxStore/actions/cart.actions';
import { CartState } from '../stateManagerReduxStore/state/cart.state';

@Component({

  selector: 'products',
  templateUrl: './products.component.html',
})

export class ProductsComponent {
  @Output() changeDisplayEvent = new EventEmitter<boolean>();
  cartProducts: Product[];
  cart: Observable<Cart[]>;
  public country: Country;
  amountTotal: number;
  itemsInBasket: number;
  private suscription: Subscription;

  constructor(private store: Store<CartState>, private productsService: ProductsService, private sharedInfoService: SharedInfoService) { }
 
  ngOnInit() {
    this.amountTotal = 0;
    this.itemsInBasket = 0;
    this.sharedInfoService.selectedCountry.subscribe((value) => {
    this.country = value;
      if (this.country !== null) {
        this.loadProductsForCart();
      }
    });
  }
  loadProductsForCart() {
    this.productsService.getProductsList(this.country.id).subscribe((Products: Product[]) => {
      this.cartProducts = Products;
    });
    //update store if item already added to basket..
     this.store.dispatch(new CartActions.UpdateUnitPrice(parseFloat(this.country.exchangeRate)));
  }

  addProductToCart(paramProduct: Product) {
    //Push item in redux store
    this.amountTotal = this.amountTotal + parseFloat(paramProduct.sellingPrice)
    this.store.dispatch(new CartActions.AddToCart({
      products: [{
        productId: paramProduct.id,
        productName: paramProduct.name, quantity: 1, unitPrice: parseFloat(paramProduct.baseUnitPrice), sellPrice: parseFloat(paramProduct.sellingPrice)
      }],
      subTotal: this.amountTotal
    }));
  }
  goToBasket() {
    this.changeDisplayEvent.emit(false);
  }
  onDestroy() {
    this.suscription.unsubscribe();
  }
  
  get total() {
    //read total from redux store
    let total;
    this.suscription = this.store.select('cart').subscribe((data) => {
      if(data){
        total = data.subTotal;
        this.itemsInBasket = data.products.length;
      }
    });
    return total;
  }
} 
