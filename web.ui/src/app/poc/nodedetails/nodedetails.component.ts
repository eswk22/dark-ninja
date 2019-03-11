import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  ViewChild
} from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { MatPaginator, MatTableDataSource } from '@angular/material';

import { ROUTE_ANIMATIONS_ELEMENTS } from '@app/core';

export interface PeriodicElement {
  name: string;
  position: number;
  Today: number;
  f_days: number;
  t_days: number;
  of_days: number;
  to_days: number;
  tho_days: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 1,
    name: 'DB Connection Count',
    Today: 20,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 2,
    name: 'Active DB Connections',
    Today: 10,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 3,
    name: 'Disk space Utilization',
    Today: 6,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 4,
    name: 'CPU Utilization',
    Today: 9,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 5,
    name: 'Load Average',
    Today: 10,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 6,
    name: 'Network Throughput',
    Today: 12,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 7,
    name: 'Memory Utilization',
    Today: 14,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 8,
    name: 'JVM Heap Utilization',
    Today: 15,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 9,
    name: 'Traffic count',
    Today: 18,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 10,
    name: 'DB Instance availability',
    Today: 20,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  },
  {
    position: 11,
    name: '# of Open iNodes',
    Today: 20,
    f_days: 20,
    t_days: 20,
    of_days: 20,
    to_days: 20,
    tho_days: 20
  }
];

@Component({
  selector: 'darkninja-nodedetails',
  templateUrl: './nodedetails.component.html',
  styleUrls: ['./nodedetails.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class NodedetailsComponent implements OnInit {
  displayedColumns: string[] = [
    'name',
    'Today',
    'f_days',
    't_days',
    'of_days',
    'to_days',
    'tho_days'
  ];

  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  panelOpenState = true;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  name: string;

  constructor() {}

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.panelOpenState = true;
  }

  openDialog(): void {}
}
