import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SnacksListComponent } from './snacks-list/snacks-list.component';

@NgModule({
  declarations: [SnacksListComponent],
  imports: [
    CommonModule
  ],
  exports: [SnacksListComponent]
})
export class SnacksModule { }
