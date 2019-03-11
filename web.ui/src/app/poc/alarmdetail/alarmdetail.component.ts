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
  hour1: number;
  hour2: number;
  hour3: number;
  hour4: number;
  hour5: number;
  hour6: number;
  hour7: number;
  hour8: number;
  hour9: number;
  hour10: number;
  hour11: number;
  hour12: number;
  hour13: number;
  hour14: number;
  hour15: number;
  hour16: number;
  hour17: number;
  hour18: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 1,
    name: 'DB Connection Count',
    hour1: 12,
    hour2: 5,
    hour3: 87,
    hour4: 22,
    hour5: 9,
    hour6: 15,
    hour7: 48,
    hour8: 8,
    hour9: 12,
    hour10: 70,
    hour11: 71,
    hour12: 87,
    hour13: 75,
    hour14: 73,
    hour15: 79,
    hour16: 85,
    hour17: 85,
    hour18: 87
  },
  {
    position: 2,
    name: 'Active DB Connections',
    hour1: 5,
    hour2: 8,
    hour3: 10,
    hour4: 5,
    hour5: 22,
    hour6: 25,
    hour7: 22,
    hour8: 29,
    hour9: 40,
    hour10: 45,
    hour11: 90,
    hour12: 20,
    hour13: 15,
    hour14: 19,
    hour15: 16,
    hour16: 23,
    hour17: 21,
    hour18: 19
  },
  {
    position: 3,
    name: 'Disk space Utilization',
    hour1: 9,
    hour2: 10,
    hour3: 8,
    hour4: 18,
    hour5: 27,
    hour6: 17,
    hour7: 12,
    hour8: 17,
    hour9: 5,
    hour10: 87,
    hour11: 87,
    hour12: 87,
    hour13: 87,
    hour14: 87,
    hour15: 87,
    hour16: 90,
    hour17: 87,
    hour18: 91
  },
  {
    position: 4,
    name: 'CPU Utilization',
    hour1: 16,
    hour2: 3,
    hour3: 17,
    hour4: 90,
    hour5: 17,
    hour6: 17,
    hour7: 7,
    hour8: 7,
    hour9: 17,
    hour10: 87,
    hour11: 87,
    hour12: 87,
    hour13: 87,
    hour14: 87,
    hour15: 87,
    hour16: 81,
    hour17: 87,
    hour18: 89
  },
  {
    position: 5,
    name: 'Load Average',
    hour1: 12,
    hour2: 19,
    hour3: 27,
    hour4: 10,
    hour5: 37,
    hour6: 10,
    hour7: 11,
    hour8: 71,
    hour9: 29,
    hour10: 87,
    hour11: 17,
    hour12: 28,
    hour13: 87,
    hour14: 4,
    hour15: 6,
    hour16: 8,
    hour17: 13,
    hour18: 12
  },
  {
    position: 6,
    name: 'Network Throughput',
    hour1: 18,
    hour2: 10,
    hour3: 20,
    hour4: 17,
    hour5: 20,
    hour6: 20,
    hour7: 29,
    hour8: 17,
    hour9: 87,
    hour10: 21,
    hour11: 10,
    hour12: 8,
    hour13: 21,
    hour14: 1,
    hour15: 87,
    hour16: 21,
    hour17: 15,
    hour18: 10
  },
  {
    position: 7,
    name: 'Memory Utilization',
    hour1: 2,
    hour2: 8,
    hour3: 10,
    hour4: 30,
    hour5: 21,
    hour6: 21,
    hour7: 22,
    hour8: 70,
    hour9: 21,
    hour10: 2,
    hour11: 87,
    hour12: 87,
    hour13: 87,
    hour14: 12,
    hour15: 10,
    hour16: 2,
    hour17: 12,
    hour18: 13
  },
  {
    position: 8,
    name: 'JVM Heap Utilization',
    hour1: 14,
    hour2: 19,
    hour3: 15,
    hour4: 91,
    hour5: 29,
    hour6: 22,
    hour7: 19,
    hour8: 71,
    hour9: 16,
    hour10: 15,
    hour11: 5,
    hour12: 87,
    hour13: 8,
    hour14: 1,
    hour15: 4,
    hour16: 12,
    hour17: 12,
    hour18: 23
  },
  {
    position: 9,
    name: 'Traffic count',
    hour1: 34,
    hour2: 20,
    hour3: 19,
    hour4: 30,
    hour5: 33,
    hour6: 25,
    hour7: 38,
    hour8: 65,
    hour9: 14,
    hour10: 87,
    hour11: 87,
    hour12: 13,
    hour13: 16,
    hour14: 9,
    hour15: 87,
    hour16: 12,
    hour17: 12,
    hour18: 21
  },
  {
    position: 10,
    name: 'DB Instance availability',
    hour1: 22,
    hour2: 87,
    hour3: 25,
    hour4: 27,
    hour5: 47,
    hour6: 10,
    hour7: 29,
    hour8: 7,
    hour9: 23,
    hour10: 12,
    hour11: 1,
    hour12: 87,
    hour13: 15,
    hour14: 87,
    hour15: 87,
    hour16: 5,
    hour17: 1,
    hour18: 7
  },
  {
    position: 11,
    name: '# of Open iNodes',
    hour1: 1,
    hour2: 13,
    hour3: 19,
    hour4: 28,
    hour5: 35,
    hour6: 30,
    hour7: 35,
    hour8: 40,
    hour9: 47,
    hour10: 30,
    hour11: 19,
    hour12: 18,
    hour13: 17,
    hour14: 10,
    hour15: 20,
    hour16: 21,
    hour17: 20,
    hour18: 10
  }
];

@Component({
  selector: 'darkninja-alarmdetail',
  templateUrl: './alarmdetail.component.html',
  styleUrls: ['./alarmdetail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AlarmdetailComponent implements OnInit {
  displayedColumns: string[] = [
    'name',
    'h_eighteen',
    'h_seventeen',
    'h_sixteen',
    'h_fifteen',
    'h_fourteen',
    'h_thirteen',
    'h_twelve',
    'h_eleven',
    'h_ten',
    'h_nine',
    'h_eight',
    'h_seven',
    'h_six',
    'h_five',
    'h_four',
    'h_three',
    'h_two',
    'h_one'
  ];

  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  panelOpenState = true;
  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  name: string;
  parameter: string;

  constructor() {}

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.panelOpenState = true;
    this.name = 'Node1';
    this.parameter = '';
  }

  openDialog(): void {}
}
