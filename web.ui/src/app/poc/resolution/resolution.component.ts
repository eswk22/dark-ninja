import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'darkninja-resolution',
  templateUrl: './resolution.component.html',
  styleUrls: ['./resolution.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ResolutionComponent implements OnInit {

  parameters: Param[] = [
    {value: 'param-1', viewValue: 'Disk space Utilization'},
    {value: 'param-4', viewValue: 'CPU Utilization'},
    {value: 'param-5', viewValue: 'DB Connection Count'}
  ];
  selected = 'param-2';
  constructor() { }

  ngOnInit() {
  }

}
export interface Param {
  value: string;
  viewValue: string;
}
