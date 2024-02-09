import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { MaterialModule } from '../../../material.module';
import { EditUserModalModule } from './edit-user-modal/edit-user-modal.module';
import { DeleteUserModalModule } from './delete-user-modal/delete-user-modal.module';
import { AddUserModalModule } from './add-user-modal/add-user-modal.module';


@NgModule({
  declarations: [
    UsersComponent,
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    MaterialModule,
    AddUserModalModule,
    EditUserModalModule,
    DeleteUserModalModule
  ]
})
export class UsersModule { }
