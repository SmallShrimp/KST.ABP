import { NgModule, APP_INITIALIZER } from '@angular/core';
import { OrganizationsConfigService } from './services/organizations-config.service';
import { noop } from '@abp/ng.core';
import { OrganizationsSettingsComponent } from './components/organizations-settings.component';

@NgModule({
  declarations: [OrganizationsSettingsComponent],
  providers: [{ provide: APP_INITIALIZER, deps: [OrganizationsConfigService], multi: true, useFactory: noop }],
  exports: [OrganizationsSettingsComponent],
  entryComponents: [OrganizationsSettingsComponent],
})
export class OrganizationsConfigModule {}
