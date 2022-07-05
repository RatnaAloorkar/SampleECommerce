import { ICart } from 'src/app/models/cart.model';
import * as CartActions from '../actions/cart.actions'

const initialState: ICart = { products: [], subTotal: 0 }

export function CartReducer(state: ICart = initialState, action: CartActions.Actions) {

  switch (action.type) {
    case CartActions.ADD_TO_BASKET:
      return {
        ...state,
        products: [...state.products, action.payload.products[0]],
        subTotal: action.payload.subTotal
      };
    case CartActions.UPDATE_UNIT_PRICE:
      if (state.subTotal > 0) {
        const productsToCheckout = [...state.products];
        productsToCheckout.forEach(product => product.sellPrice = product.unitPrice * action.payload);
        const subTotal = productsToCheckout.reduce((value, product) => {
          return value + product.sellPrice;
        }, 0);
        return {
          ...state,
          products: productsToCheckout,
          subTotal
        };
      }
      else
        return state;
    case CartActions.REMOVE_FROM_BASKET:
      const filteredProducts = state.products.filter(product => parseInt(product.productId) !== action.payload);
      const subTotal = filteredProducts.reduce((value, product) => {
        return value + product.sellPrice;
      }, 0);
      return {
        ...state,
        products: filteredProducts,
        subTotal
      };

    default:
      return state;
  }
}
