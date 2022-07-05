import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment.prod';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CartDetailsComponent } from './component/cart-details.component';
import { CountryComponent } from './component/country.component ';
import { OrderPlacedComponent } from './component/order-placed.component';
import { ProductsComponent } from './component/products.component';
import { CartContainer } from './container/cart.container';
import { CountriesService } from './service/countries.service';
import { SharedInfoService } from './service/shared-info.service';
import { OrderService } from './service/order.service';
import { ProductsService } from './service/products.service';
import { CartReducer } from './stateManagerReduxStore/reducer/cart.reducer';
import { SingularPluralPipe } from './pipes/singularpluralpipe';
import { NoCommaPipe } from './pipes/NoCommaPipe'
import { pathNotFoundComponent } from './component/pathNotFound.component';

@NgModule({
  declarations: [
    AppComponent,
    CartContainer,
    CountryComponent,
    ProductsComponent,
    CartDetailsComponent,
    OrderPlacedComponent,
    SingularPluralPipe,
    NoCommaPipe,
    pathNotFoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    StoreModule.forRoot({
      cart: CartReducer
    }),
    StoreDevtoolsModule.instrument({
      name: 'Test Redux',
      maxAge: 25,
      logOnly: environment.production
    }),
  ],
  providers: [SharedInfoService, CountriesService, ProductsService, OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
