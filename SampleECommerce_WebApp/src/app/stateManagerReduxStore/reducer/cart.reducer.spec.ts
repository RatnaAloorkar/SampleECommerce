import { CartReducer } from './cart.reducer';
import * as CartActions from '../actions/cart.actions'
import { ICart } from 'src/app/models/cart.model';
//Check Initial State...
describe('Reducer: cartReducer', () => {
  it('should have initial state of ICart to empty object', () => {
    const expected: ICart = { products: [], subTotal: 0 }
    const action: CartActions.Actions = { type: null } as any;
    expect(CartReducer(undefined, action)).toEqual(expected);
  });
});
//Check Initial State...
describe('Reducer: cartReducer', () => {
  it('should add one product to the store', () => {
    const expectedProductInStore: ICart = {
      products: [
        { productId: "1", productName: "Test Product", quantity: 1, unitPrice: 250, sellPrice:250 }
      ], subTotal: 250, total: 0
    };
    const action = new CartActions.AddToCart(expectedProductInStore);
    expect(CartReducer({ products: [], total: 0 }, action)).toEqual(expectedProductInStore);
  });
});

describe('Reducer: cartReducer', () => {
  it('should remove product from the store', () => {
    const initialState: ICart = {
      products: [
        { productId: "1", productName: "Test Product1", quantity: 1, unitPrice: 100, sellPrice: 100 },
        { productId: "2", productName: "Test Product2", quantity: 1, unitPrice: 100, sellPrice: 100 },
        { productId: "3", productName: "Test Product3", quantity: 1, unitPrice: 100, sellPrice: 100}
      ], subTotal: 300
    };

    const expectedProductsInStore: ICart = {
      products: [
        { productId: "2", productName: "Test Product2", quantity: 1, unitPrice: 100, sellPrice: 100 },
        { productId: "3", productName: "Test Product3", quantity: 1, unitPrice: 100, sellPrice: 100 }
      ], subTotal: 200
    };


    //remove product 1
    const action = new CartActions.RemoveFromCart(1);
    expect(CartReducer(initialState, action)).toEqual(expectedProductsInStore);
  });
});

describe('Reducer: cartReducer', () => {
  it('should correctly update the sellPrice and Total based on the exchange rate', () => {

    const exchangeRate = 0.5;

    const initialState: ICart = {
      products: [
        { productId: "1", productName: "Test Product1", quantity: 1, unitPrice: 100, sellPrice: 100},
        { productId: "2", productName: "Test Product2", quantity: 1, unitPrice: 100, sellPrice: 100},
        
      ], subTotal: 200
    };

    const expectedProductsInStore: ICart = {
      products: [
        { productId: "1", productName: "Test Product1", quantity: 1, unitPrice: 100, sellPrice: 100 * exchangeRate },
        { productId: "2", productName: "Test Product2", quantity: 1, unitPrice: 100, sellPrice: 100 * exchangeRate }
      ], subTotal: 200 * exchangeRate
    };
  const action = new CartActions.UpdateUnitPrice(exchangeRate);
    expect(CartReducer(initialState, action)).toEqual(expectedProductsInStore);
  });
});
