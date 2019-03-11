import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpClient } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { SharedModule } from '@app/shared';
import { environment } from '@env/environment';

import { PocRoutingModule } from './poc-routing.module';
import { AlarminfoComponent } from './alarminfo/alarminfo.component';
import { MetricsComponent } from './metrics/metrics.component';
import { ShellComponent } from './shell/shell.component';
import { ResolutionComponent } from './resolution/resolution.component';
import { AlarmdetailComponent } from './alarmdetail/alarmdetail.component';
import { NodedetailsComponent } from './nodedetails/nodedetails.component';

@NgModule({
  declarations: [
    AlarminfoComponent,
    MetricsComponent,
    ShellComponent,
    ResolutionComponent,
    AlarmdetailComponent,
    NodedetailsComponent
  ],
  imports: [
    SharedModule,
    //  StoreModule.forFeature(FEATURE_NAME, reducers),
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: true
    }),
    CommonModule,
    PocRoutingModule
  ]
})
export class PocModule {}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(
    http,
    '${environment.i18nPrefix}/assets/i18n/poc/',
    '.json'
  );
}
