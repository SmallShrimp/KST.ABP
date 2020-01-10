import { NgModule } from '@angular/core';
import { OrganizationsComponent } from './components/organizations.component';
import { OrganizationsRoutingModule } from './organizations-routing.module';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [OrganizationsComponent],
  imports: [CoreModule, ThemeSharedModule, OrganizationsRoutingModule],
  exports: [OrganizationsComponent],
})
export class OrganizationsModule {}
