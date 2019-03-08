import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlarminfoComponent } from './alarminfo.component';

describe('AlarminfoComponent', () => {
  let component: AlarminfoComponent;
  let fixture: ComponentFixture<AlarminfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlarminfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlarminfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
