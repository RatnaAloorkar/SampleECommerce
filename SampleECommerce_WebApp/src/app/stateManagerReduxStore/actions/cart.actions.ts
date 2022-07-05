import { Action } from '@ngrx/store'
import { ICart } from 'src/app/models/cart.model'

export const ADD_TO_BASKET = '[CART] Add Product'
export const REMOVE_FROM_BASKET = '[CART] Remove Product'
export const UPDATE_UNIT_PRICE = '[CART] Update UnitPrice'

export class AddToCart implements Action {
  readonly type = ADD_TO_BASKET

  constructor(public payload: ICart) { }
}

export class RemoveFromCart implements Action {
  readonly type = REMOVE_FROM_BASKET

  constructor(public payload: number) { }
}

export class UpdateUnitPrice implements Action {
  readonly type = UPDATE_UNIT_PRICE

  constructor(public payload: number) { }
}
export type Actions = AddToCart | RemoveFromCart | UpdateUnitPrice
