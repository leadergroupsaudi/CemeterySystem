import { Component, Injector, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponentBase } from '@shared/app-component-base';
import { LookUpsServiceProxy, RegionDto, VolunteerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-volunteer',
  templateUrl: './volunteer.component.html',
  styleUrl: './volunteer.component.css'
})
export class VolunteerComponent extends AppComponentBase implements OnInit {
  regions: RegionDto[] = [];
  constructor(injector: Injector,
    private VolunteerService: VolunteerServiceProxy,
    private LookUpService: LookUpsServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this.LookUpService.getRegions().subscribe((result: RegionDto[]) => {
      this.regions = result;
    })
  }
}
