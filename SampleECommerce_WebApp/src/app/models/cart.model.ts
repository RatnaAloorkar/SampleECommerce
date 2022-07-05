export interface ICart {
  products?: Cart[];
  subTotal?: number;
  total?: number;
}

export class Cart {
  constructor(
    public productId?: string,
    public productName?: string,
    public quantity?: number,
    public unitPrice?: number,
    public sellPrice?: number

  ) { }
}