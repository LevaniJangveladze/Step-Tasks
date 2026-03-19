import { Routes } from '@angular/router';
import { Main } from './main/main';
import { Cart } from './cart/cart';
import { About } from './about/about';

export const routes: Routes = [
  { path: '', component: Main },
  { path: 'cart', component: Cart },
  { path: 'about', component: About },
];