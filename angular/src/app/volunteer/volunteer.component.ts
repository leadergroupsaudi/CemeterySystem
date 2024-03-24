import { Component, Injector, OnInit } from '@angular/core';
import { guid } from '@progress/kendo-angular-common';
import { AppComponentBase } from '@shared/app-component-base';
import { CityDto, LookUpsServiceProxy, RegionDto, VolunteerServiceProxy, DistrictDto, CemeteryDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-volunteer',
  templateUrl: './volunteer.component.html',
  styleUrls: ['./volunteer.component.css']
})
export class VolunteerComponent extends AppComponentBase implements OnInit {
  regions: RegionDto[] = [];
  cities: CityDto[] = [];
  districts: DistrictDto[] = [];
  cemeteries: CemeteryDto[] = [];
  selectedRegion: number;
  selectedCity: number;
  selectedDistrict: number;
  selectedCemetery: number;

  constructor(
    injector: Injector,
    private volunteerService: VolunteerServiceProxy,
    private lookUpService: LookUpsServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.loadRegions();
  }

  loadRegions(): void {
    this.lookUpService.getRegions().subscribe((result: RegionDto[]) => {
      this.regions = result;
      if (this.regions.length > 0) {
        this.selectedRegion = this.regions[0].id;
        this.onRegionChange(); // Load cities for the first region
      }
    });
  }

  onRegionChange(): void {
    this.loadCities(this.selectedRegion);
  }

  loadCities(regionId: number): void {
    this.lookUpService.getCities(regionId).subscribe((result: CityDto[]) => {
      this.cities = result;
      this.selectedCity = null; // Reset selected city
      this.districts = []; // Clear districts
      this.cemeteries = []; // Clear cemeteries when city changes
    });
  }

  onCityChange(): void {
    this.loadDistricts(this.selectedCity);
    this.loadCemeteries(this.selectedCity); // Load cemeteries for the selected city
  }

  loadDistricts(cityId: number): void {
    this.lookUpService.getDistricts(cityId).subscribe((result: DistrictDto[]) => {
      this.districts = result;
    });
  }

  loadCemeteries(cityId: number): void {
    this.lookUpService.getCemeteries(cityId).subscribe((result: CemeteryDto[]) => {
      this.cemeteries = result;
    });
  }
}

