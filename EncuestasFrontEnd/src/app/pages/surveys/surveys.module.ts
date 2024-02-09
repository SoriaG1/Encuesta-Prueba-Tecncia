import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveysComponent } from './surveys.component';
import { MaterialModule } from '../../../material.module';
import { SurveysRoutingModule } from './surveys-routing.module';



@NgModule({
  declarations: [
    SurveysComponent
  ],
  imports: [
    CommonModule,
    SurveysRoutingModule,
    MaterialModule
  ],
  exports: [
    SurveysComponent
  ]
})
export class SurveysModule { }
