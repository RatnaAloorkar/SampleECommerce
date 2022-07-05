import { SharedInfoService } from '../service/shared-info.service';
import { ProductsService } from '../service/products.service';
import { ProductsComponent } from './products.component';
import { NoCommaPipe } from '../pipes/NoCommaPipe';
import { SingularPluralPipe } from '../pipes/singularpluralpipe';
import { async, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { of } from 'rxjs';
import { Country } from '../models/country.model';

describe('Component:ProductsComponent', () => {
  const mockSharedInfoService = new SharedInfoService();
  const mockProductsService = new ProductsService(null);
  const mockStore = jasmine.createSpyObj('Store', ['select', 'dispatch']);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsComponent,NoCommaPipe,SingularPluralPipe],
      providers: [
        { provide: Store, useValue: mockStore },
        { provide: ProductsService, useValue: mockProductsService },
        { provide: SharedInfoService, useValue: mockSharedInfoService },
        { provide: Router, useValue: null },
      ]
    }).compileComponents();
  }));

  it('should instantiate component', () => {
    const fixture = TestBed.createComponent(ProductsComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should show products if country is  selected', () => {
    const fixture = TestBed.createComponent(ProductsComponent);
    const component = fixture.debugElement.componentInstance;

    component.country = new Country('1', 'Australia', 'AUD', '1');
    
    spyOnProperty(mockSharedInfoService, "selectedCountry", 'get').and.returnValue(of(1));
    spyOn(mockProductsService, "getProductsList").and.returnValue(of([{
      productId: "1",
      productName: "Test Product", quantity: "1", unitPrice: 100, sellPrice: 100
    }]));
    component.ngOnInit();
    expect(component.cartProducts.length).toEqual(1);
  });

  it('should not show products if country is not selected', () => {
    const fixture = TestBed.createComponent(ProductsComponent);
    const component = fixture.debugElement.componentInstance;

    component.country = null;
   
    spyOn(mockProductsService, "getProductsList").and.returnValue(of([]));
    component.ngOnInit();
    expect(component.cartProducts).toEqual(undefined);
  });
});
