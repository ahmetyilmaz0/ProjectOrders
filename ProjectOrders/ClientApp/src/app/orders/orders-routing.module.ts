import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  { path: 'orders', redirectTo: 'orders/list', pathMatch: 'full' },
  { path: 'orders/list', component: ListComponent },
  { path: 'orders/:OrderID/details', component: DetailsComponent },
  { path: 'orders/create', component: CreateComponent },
  { path: 'orders/:OrderID/update', component: UpdateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
