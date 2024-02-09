import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserModalComponent } from './add-user-modal.component';
import { MaterialModule } from '../../../../material.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddUserModalComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule
  ],
  exports: [
    AddUserModalComponent
  ]
})
export class AddUserModalModule { }
