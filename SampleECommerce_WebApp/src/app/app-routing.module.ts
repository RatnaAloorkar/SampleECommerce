import { RouterModule, Routes } from '@angular/router';
import { CartContainer } from './container/cart.container';
import { OrderPlacedComponent } from './component/order-placed.component';
import { NgModule } from '@angular/core';
import { pathNotFoundComponent } from './component/pathNotFound.component';

const routes: Routes = [
  { path: 'cart', component: CartContainer },
  { path: 'order-placed', component: OrderPlacedComponent },
  { path: '', component: CartContainer, pathMatch: 'full' },
  { path: '**', component: pathNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
