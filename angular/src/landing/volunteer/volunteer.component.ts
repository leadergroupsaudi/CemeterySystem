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
  volunteerNameInvalid: boolean = false;
  PhoneNumberInvalid: boolean = false;

  volunteerRegions: RegionDto[];
  volunteerSelectedRegion: RegionDto;
  volunteerCities: CityDto[];
  volunteerSelectedCity: CityDto;
  volunteerDistricts: DistrictDto[];
  volunteerSelectedDistrict: DistrictDto;
  isDisabledVolunteerCity = true;
  isDisabledVolunteerDistrict = true;
  defaultVolunteerRegion = { id: null, nameAr: this.l("ChooseRegion") };
  defaultVolunteerCity = { id: null, nameAr: this.l("ChooseCity") };
  defaultVolunteerDistrict = { id: null, nameAr: this.l("ChooseDistrict") };


  cemeteryRegions: RegionDto[] = [];
  cemeterySelectedRegion: RegionDto;
  cemeteryCities: CityDto[] = [];
  cemeterySelectedCity: CityDto;
  cemeteriesData: CemeteryDto[] = [];
  selectedCemeteryData: CemeteryDto;
  isDisabledCemeteryCity = true;
  isDisabledCemeteryData = true;
  defaultCemeteryRegion = { id: null, nameAr: this.l("ChooseRegion") };
  defaultCemeteryCity = { id: null, nameAr: this.l("ChooseCity") };
  defaultCemeteryData = { id: null, nameAr: this.l("ChooseCemetery") };
  cemeteryObjects: CemeteryObject[] = [];

  isAcceptedTermsAndConditions: boolean = false;
  successMessageVisible: boolean = false;
  language = abp.localization.currentLanguage.name
  isArabic = this.language === 'ar';

  constructor(injector: Injector,
    private VolunteerService: VolunteerServiceProxy,
    private LookUpService: LookUpsServiceProxy,) {
    super(injector);
  }

  ngOnInit(): void {
    console.log(this.language)
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
    if (!this.selectedCemeteryData) {
      this.message.info(this.l("YouHaveToSelectACemeteryToAdd"));
    }
    else {
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
      else {
        this.message.info(this.l("CantAddSameCemeteryTwice"))
      }
    }
  }

  addVolunteer(): void {
    if (this.validateVolunteer()) {
      this.createVolunteer();
    }
  }

  validateVolunteer(): boolean {
    if (!this.volunteerName || this.volunteerName.length < 3) {
      this.message.info(this.l("VolunteerNameRequired"));
      this.volunteerNameInvalid = true;
      return false;
    }
    if (!this.volunteerPhoneNumber) {
      this.PhoneNumberInvalid = true;
      this.message.info(this.l("PhoneNumberRequired"));
      return false;
    }
    if (!this.volunteerSelectedDistrict || !this.volunteerSelectedDistrict.id) {
      this.message.info(this.l("YouMustChooseYourDistrict"));
      return false;
    }
    if (!this.isAcceptedTermsAndConditions) {
      this.message.info(this.l("YouMustAgreeToTheTermsAndConditions"));
      return false;
    }
    return true;
  }




  createVolunteer(): void {
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
    this.VolunteerService.createVolunteer(this.isAcceptedTermsAndConditions, volunteerData)
      .subscribe(() => { this.notify.info(this.l("RegisteredSuccessfully")) });
    this.successMessageVisible = true;
  }

}


