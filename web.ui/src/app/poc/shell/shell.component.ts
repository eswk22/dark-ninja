import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'darkninja-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ShellComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
