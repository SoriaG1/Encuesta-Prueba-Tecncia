import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SignInRoutingModule } from './sign-in-routing.module';
import { SignInComponent } from './sign-in.component';
import { MaterialModule } from '../../../material.module';
import { LoginFormModule } from '../../components/login-form/login-form.module';


@NgModule({
  declarations: [
    SignInComponent
  ],
  imports: [
    CommonModule,
    SignInRoutingModule,
    MaterialModule,
    LoginFormModule
  ]
})
export class SignInModule { }
