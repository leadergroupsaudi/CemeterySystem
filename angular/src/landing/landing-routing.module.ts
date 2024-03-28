import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing.component';
// import { NavbarComponent } from './navbar/navbar.component';
import { VolunteerComponent } from './volunteer/volunteer.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    {
      path: '',
      component: LandingComponent,
      children: [
        // { path: 'navbar', component: NavbarComponent }
        // { path: 'register', component: RegisterComponent }
        { path: 'volunteer', component: VolunteerComponent },

      ]
    }
  ])],
  exports: [RouterModule]
})
export class LandingRoutingModule { }
