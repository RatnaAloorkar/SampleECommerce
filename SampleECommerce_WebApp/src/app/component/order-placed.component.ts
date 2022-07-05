import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({

  selector: 'order-placed',
  templateUrl: './order-placed.component.html'
})
export class OrderPlacedComponent {
  public orderNumber: string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(){
    this.route.queryParams.subscribe(params => {
      this.orderNumber = params.orderNo;
    })
  }
} 
