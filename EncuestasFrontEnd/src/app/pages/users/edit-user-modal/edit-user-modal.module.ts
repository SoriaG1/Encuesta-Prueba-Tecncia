import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditUserModalComponent } from './edit-user-modal.component';
import { MaterialModule } from '../../../../material.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    EditUserModalComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule
  ],
  exports: [
    EditUserModalComponent
  ]
})
export class EditUserModalModule { }
