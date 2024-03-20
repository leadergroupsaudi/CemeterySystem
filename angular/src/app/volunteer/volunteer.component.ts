import { Component, Injector, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponentBase } from '@shared/app-component-base';
import { VolunteerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-volunteer',
  templateUrl: './volunteer.component.html',
  styleUrl: './volunteer.component.css'
})
export class VolunteerComponent extends AppComponentBase implements OnInit {

  constructor(injector: Injector, private VolunteerService: VolunteerServiceProxy) {
    super(injector);
  }
  ngOnInit(): void {
this.VolunteerService.createVolunteer
  }
}
