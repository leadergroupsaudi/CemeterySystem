import { Component, Injector, OnInit } from '@angular/core';
import { guid } from '@progress/kendo-angular-common';
import { AppComponentBase } from '@shared/app-component-base';
import { CemeteryDto, CityDto, DistrictDto, LookUpsServiceProxy, RegionDto, VolunteerInput, VolunteerOrderInput, VolunteerServiceProxy } from '@shared/service-proxies/service-proxies';
import { SVGIcon, folderIcon } from "@progress/kendo-svg-icons";

interface ICemeteryObject {
  cemeteryId: string,
  CemeteryName: string;
  RegionName: string,
  CityName: string
}

export class CemeteryObject implements ICemeteryObject {
  cemeteryId: string;
  CemeteryName: string;
  RegionName: string;
  CityName: string;
}
@Component({
  selector: 'app-volunteer',
  templateUrl: './volunteer.component.html',
  styleUrls: ['./volunteer.component.css']
})
export class VolunteerComponent extends AppComponentBase implements OnInit {
  folderSVG: SVGIcon = folderIcon;
  volunteerName: string | null = null;
  volunteerPhoneNumber: string | null = null;

  volunteerRegions: RegionDto[];
  volunteerSelectedRegion: RegionDto;
  volunteerCities: CityDto[];
  volunteerSelectedCity: CityDto;
  volunteerDistricts: DistrictDto[];
  volunteerSelectedDistrict: DistrictDto;
  isDisabledVolunteerCity = true;
  isDisabledVolunteerDistrict = true;
  defaultVolunteerRegion = { id: null, nameAr: "اختر المنطقة" };
  defaultVolunteerCity = { id: null, nameAr: "اختر المدينة" };
  defaultVolunteerDistrict = { id: null, nameAr: "اختر الحي" };


  cemeteryRegions: RegionDto[] = [];
  cemeterySelectedRegion: RegionDto;
  cemeteryCities: CityDto[] = [];
  cemeterySelectedCity: CityDto;
  cemeteriesData: CemeteryDto[] = [];
  selectedCemeteryData: CemeteryDto;
  isDisabledCemeteryCity = true;
  isDisabledCemeteryData = true;
  defaultCemeteryRegion = { id: null, nameAr: "اختر المنطقة" };
  defaultCemeteryCity = { id: null, nameAr: "اختر المدينة" };
  defaultCemeteryData = { id: null, nameAr: "اختر المقبرة" };
  cemeteryObjects: CemeteryObject[] = [];

  isAcceptedTermsAndConditions: boolean = false;
  successMessageVisible: boolean = false;

  constructor(injector: Injector,
    private VolunteerService: VolunteerServiceProxy,
    private LookUpService: LookUpsServiceProxy,) {
    super(injector);
  }

  ngOnInit(): void {
    this.LookUpService.getRegions().subscribe((result: RegionDto[]) => {
      console.log(result);
      this.volunteerRegions = result;
      this.cemeteryRegions = result;
    })
  }


  handleVolunteerRegionChange(value) {
    this.volunteerSelectedRegion = value;
    this.volunteerSelectedCity = undefined;
    this.volunteerSelectedDistrict = undefined;
    if (value.id === this.defaultVolunteerRegion.id) {
      this.isDisabledVolunteerCity = true;
      this.volunteerCities = [];
    }
    else {
      this.isDisabledVolunteerCity = false;
      var regionId = this.volunteerSelectedRegion.id;
      this.LookUpService.getCities(regionId).subscribe((result: CityDto[]) => {
        this.volunteerCities = result;
      })
    }
    this.isDisabledVolunteerDistrict = true;
    this.volunteerDistricts = [];
  }

  handleVolunteerCityChange(value) {
    this.volunteerSelectedCity = value;
    this.volunteerSelectedDistrict = undefined;

    if (value.id === this.defaultVolunteerCity.id) {
      this.isDisabledVolunteerDistrict = true;
      this.volunteerDistricts = [];
    }
    else {
      this.isDisabledVolunteerDistrict = false;
      var cityId = this.volunteerSelectedCity.id;
      this.LookUpService.getDistricts(cityId).subscribe((result: DistrictDto[]) => {
        this.volunteerDistricts = result;
      })
    }
  }

  handleVolunteerDistrictChange(value) {
    this.volunteerSelectedDistrict = value;
  }

  handleCemeteryRegionChange(value) {
    this.cemeterySelectedRegion = value;
    this.cemeterySelectedCity = undefined;
    this.selectedCemeteryData = undefined;
    if (value.id === this.defaultCemeteryRegion.id) {
      this.isDisabledCemeteryCity = true;
      this.cemeteryCities = [];
    }
    else {
      this.isDisabledCemeteryCity = false;
      var regionId = this.cemeterySelectedRegion.id;
      this.LookUpService.getCities(regionId).subscribe((result: CityDto[]) => {
        this.cemeteryCities = result;
      })
    }
    this.isDisabledCemeteryData = true;
    this.cemeteriesData = [];
  }

  handleCemeteryCityChange(value) {
    this.cemeterySelectedCity = value;
    this.selectedCemeteryData = undefined;

    if (value.id === this.defaultCemeteryCity.id) {
      this.isDisabledCemeteryData = true;
      this.cemeteriesData = [];
    }
    else {
      this.isDisabledCemeteryData = false;
      var cityId = this.cemeterySelectedCity.id;
      this.LookUpService.getCemeteries(cityId).subscribe((result: CemeteryDto[]) => {
        this.cemeteriesData = result;
      })
    }
  }

  handleCemeteryChange(value) {
    this.selectedCemeteryData = value;
  }

  addCemeteryForVolunteer(): void {
    console.log(this.selectedCemeteryData.id);
    console.log(this.cemeteryObjects);
    if (this.selectedCemeteryData.id && !this.cemeteryObjects.find(
      obj => obj.cemeteryId == this.selectedCemeteryData.id)) {
      {
        this.cemeteryObjects.push({
          cemeteryId: this.selectedCemeteryData.id,
          CemeteryName: this.selectedCemeteryData.nameAr,
          RegionName: this.cemeterySelectedRegion.nameAr,
          CityName: this.cemeterySelectedCity.nameAr
        });
        this.selectedCemeteryData.id = null;
      }
    }
  }

  addVolunteer(): void {
    console.log(this.volunteerSelectedDistrict.id);
    const volunteerData = new VolunteerInput();
    volunteerData.id = undefined;
    volunteerData.nameAr = this.volunteerName;
    volunteerData.phone = this.volunteerPhoneNumber;
    volunteerData.districtId = this.volunteerSelectedDistrict.id;
    const volunteerOrderInputs: VolunteerOrderInput[] = [];
    for (const cemeteryObject of this.cemeteryObjects) {
      const volunteerOrderInput = new VolunteerOrderInput();
      volunteerOrderInput.cemeratyId = cemeteryObject.cemeteryId;
      volunteerOrderInputs.push(volunteerOrderInput);
    }
    volunteerData.volunteerOrderInputs = volunteerOrderInputs;
    console.log(volunteerData);
    this.VolunteerService.createVolunteer(this.isAcceptedTermsAndConditions, volunteerData)
      .subscribe(() => {
      });
    this.successMessageVisible = true;
  }

}


