import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlarminfoComponent} from './alarminfo/alarminfo.component' ;
import { MetricsComponent } from './metrics/metrics.component';
import { ShellComponent } from './shell/shell.component';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: 'alarminfo',
      component: AlarminfoComponent,
      data: { title: 'darkninja.examples.menu.todos' }
    },
    {
      path: 'metrics',
      component: MetricsComponent,
      data: { title: 'darkninja.examples.menu.todos' }
    },
    {
      path: 'shell',
      component: ShellComponent,
      data: { title: 'darkninja.examples.menu.todos' }
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PocRoutingModule { }
