import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteUserModalComponent } from './delete-user-modal.component';
import { MaterialModule } from '../../../../material.module';



@NgModule({
  declarations: [
    DeleteUserModalComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    DeleteUserModalComponent
  ]
})
export class DeleteUserModalModule { }
