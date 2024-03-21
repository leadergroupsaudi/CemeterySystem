// import { Component, Injector, OnInit } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { AppComponentBase } from '@shared/app-component-base';
// import { LookUpsServiceProxy, RegionDto, VolunteerServiceProxy } from '@shared/service-proxies/service-proxies';

// @Component({
//   selector: 'app-volunteer',
//   templateUrl: './volunteer.component.html',
//   styleUrl: './volunteer.component.css'
// })
// export class VolunteerComponent extends AppComponentBase implements OnInit {
//   regions: RegionDto[] = [];
//   constructor(injector: Injector,
//     private VolunteerService: VolunteerServiceProxy,
//     private LookUpService: LookUpsServiceProxy) {
//     super(injector);
//   }
  
//   ngOnInit(): void {
//     this.LookUpService.getRegions().subscribe((result: RegionDto[]) => {
//       this.regions = result;
//     })
//   }
// }

import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CityDto, LookUpsServiceProxy, RegionDto, VolunteerServiceProxy,DistrictDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-volunteer',
  templateUrl: './volunteer.component.html',
  styleUrls: ['./volunteer.component.css']
})
export class VolunteerComponent extends AppComponentBase implements OnInit {
  regions: RegionDto[] = [];
  cities: CityDto[] = [];
  districts: DistrictDto[]=[];
  selectedRegion: number;
  selectedCity: number;
  selectedDistrict: number;

  constructor(
    injector: Injector,
    private volunteerService: VolunteerServiceProxy,
    private lookUpService: LookUpsServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.lookUpService.getRegions().subscribe((result: RegionDto[]) => {
      this.regions = result;
      if (this.regions.length > 0) {
        this.selectedRegion = this.regions[0].id;
        this.loadCities(this.selectedRegion);
      }
    });
  }

  onRegionChange(): void {
    this.loadCities(this.selectedRegion);
  }

  loadCities(regionId: number): void {
    this.lookUpService.getCities(regionId).subscribe((result: CityDto[]) => {
      this.cities = result;
      // Clear districts when cities change
      this.districts = [];
    });
  }
  loadDistrictsFromCity(cityId: number): void {
    this.lookUpService.getDistricts(cityId).subscribe((result: DistrictDto[]) => {
      this.districts = result;
    });
  }
}

