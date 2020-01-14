import { Injectable } from '@angular/core';
import { eLayoutType, addAbpRoutes, ABP } from '@abp/ng.core';
import { addSettingTab } from '@abp/ng.theme.shared';
import { OrganizationsSettingsComponent } from '../components/organizations-settings.component';

@Injectable({
  providedIn: 'root',
})
export class OrganizationsConfigService {
  constructor() {
    addAbpRoutes({
      name: 'Organizations',
      path: 'organizations',
      layout: eLayoutType.application,
      order: 2,
    } as ABP.FullRoute);

    const route = addSettingTab({
      component: OrganizationsSettingsComponent,
      name: 'Organizations Settings',
      order: 1,
      requiredPolicy: '',
    });
  }
}
