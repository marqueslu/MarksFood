import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SnacksListComponent } from './snacks/snacks-list/snacks-list.component';

const routes: Routes = [
  {path: '', component: SnacksListComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
