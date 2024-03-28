import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from './landing.component'
import { LandingRoutingModule } from './landing-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule, HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NavbarComponent } from './layout/navbar.component';
import { VolunteerComponent } from './volunteer/volunteer.component';
import { SharedModule } from "../shared/shared.module";
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { TextBoxModule } from '@progress/kendo-angular-inputs';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';


@NgModule({
  declarations: [
    LandingComponent,
    NavbarComponent,
    VolunteerComponent,
  ],
  imports: [
    CommonModule,
    LandingRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    SharedModule,
    DropDownsModule,
    LabelModule,
    ButtonModule,
    TextBoxModule,
    GridModule,
    InputsModule,
  ]
})
export class LandingModule { }
