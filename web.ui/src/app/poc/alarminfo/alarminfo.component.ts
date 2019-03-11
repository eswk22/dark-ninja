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
  node: string;
  position: number;
  ServerSerial: number;
  SpecificProbeCause: string;
  Severity: string;
  Status: string;
  FirstOccurred: string;
  ClearedOn: string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 1,
    node: 'Node1',
    ServerSerial: 234623452,
    SpecificProbeCause: 'CPU Utilization High',
    Severity: 'Major',
    Status: 'Open',
    FirstOccurred: '03/08/2019 04:54',
    ClearedOn: ''
  },
  {
    position: 2,
    node: 'Node2',
    ServerSerial: 234623433,
    SpecificProbeCause: 'Memory Utilization High',
    Severity: 'Warning',
    Status: 'Closed',
    FirstOccurred: '03/08/2019 01:04',
    ClearedOn: '03/08/2019 02:24'
  },
  {
    position: 3,
    node: 'Node3',
    ServerSerial: 897898897,
    SpecificProbeCause: 'ECE latency high',
    Severity: 'Critical',
    Status: 'Open',
    FirstOccurred: '03/08/2019 12:14',
    ClearedOn: ''
  },
  {
    position: 4,
    node: 'Node4',
    ServerSerial: 325343444,
    SpecificProbeCause: 'Memory Utilization High',
    Severity: 'Warning',
    Status: 'Open',
    FirstOccurred: '03/08/2019 04:54',
    ClearedOn: ''
  },
  {
    position: 5,
    node: 'Node3',
    ServerSerial: 890980998,
    SpecificProbeCause: 'CPU Utilization High',
    Severity: 'Major',
    Status: 'Closed',
    FirstOccurred: '03/08/2019 14:54',
    ClearedOn: '03/08/2019 15:12'
  },
  {
    position: 6,
    node: 'Node1',
    ServerSerial: 324244234,
    SpecificProbeCause: 'CPU Utilization High',
    Severity: 'Major',
    Status: 'Open',
    FirstOccurred: '03/08/2019 20:54',
    ClearedOn: ''
  },
  {
    position: 7,
    node: 'Node2',
    ServerSerial: 890890898,
    SpecificProbeCause: 'ECE latency high',
    Severity: 'Critical',
    Status: 'Open',
    FirstOccurred: '03/08/2019 14:04',
    ClearedOn: ''
  },
  {
    position: 8,
    node: 'Node5',
    ServerSerial: 123432134,
    SpecificProbeCause: 'Memory Utilization High',
    Severity: 'Major',
    Status: 'Closed',
    FirstOccurred: '03/08/2019 04:54',
    ClearedOn: '03/08/2019 05:24'
  },
  {
    position: 9,
    node: 'Node7',
    ServerSerial: 780978345,
    SpecificProbeCause: 'CPU Utilization High',
    Severity: 'Warning',
    Status: 'Open',
    FirstOccurred: '03/08/2019 03:54',
    ClearedOn: ''
  }
];

@Component({
  selector: 'darkninja-alarminfo',
  templateUrl: './alarminfo.component.html',
  styleUrls: ['./alarminfo.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AlarminfoComponent implements OnInit {
  displayedColumns: string[] = [
    'node',
    'SpecificProbeCause',
    'Severity',
    'Status',
    'FirstOccurred',
    'ClearedOn'
  ];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  panelOpenState = true;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor() {}

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.panelOpenState = true;
  }
}
