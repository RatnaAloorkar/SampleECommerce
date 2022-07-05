import { NoCommaPipe } from '../pipes/NoCommaPipe';
import { SingularPluralPipe } from '../pipes/singularpluralpipe';
import { SharedInfoService } from '../service/shared-info.service';
import { OrderService } from '../service/order.service';
import { CartDetailsComponent } from './cart-details.component';
import { async, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';

describe('Component:CartDetails', () => {
  const mockStore = jasmine.createSpyObj('Store', ['select', 'dispatch']);
  const mockSharedInfoService = new SharedInfoService();
  const mockOrderService = new OrderService(null);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CartDetailsComponent, NoCommaPipe, SingularPluralPipe],
      providers: [
        { provide: Store, useValue: mockStore },
        { provide: OrderService, useValue: mockOrderService },
        { provide: SharedInfoService, useValue: mockSharedInfoService },
        { provide: Router, useValue: null },
      ]
    }).compileComponents();
  }));

  it('should instantiate component', () => {
    const fixture = TestBed.createComponent(CartDetailsComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should set shipping as 20 if subTotal is 60', () => {
    const fixture = TestBed.createComponent(CartDetailsComponent);
    const component = fixture.debugElement.componentInstance;

    component.subTotal = 60;
    spyOn(mockOrderService, "getShippingPrice").and.returnValue(of(20));

    component.getShippingPrice();
    expect(component.shipping).toEqual(20);
    expect(component.total).toEqual(80);
  });

  it('should set shipping as 0 if subTotal is 0', () => {
    const fixture = TestBed.createComponent(CartDetailsComponent);
    const component = fixture.debugElement.componentInstance;

    component.subTotal = 0;
    spyOn(mockOrderService, "getShippingPrice").and.returnValue(of(0));
    component.getShippingPrice();
    expect(component.shipping).toEqual(0);
    expect(component.total).toEqual(0);
  });

  it('should set shipping as 10 if subTotal is 10', () => {
    const fixture = TestBed.createComponent(CartDetailsComponent);
    const component = fixture.debugElement.componentInstance;

    component.subTotal = 10;
    spyOn(mockOrderService, "getShippingPrice").and.returnValue(of(10));
 
    component.getShippingPrice();
    expect(component.shipping).toEqual(10);
    expect(component.total).toEqual(20);
  });
});
