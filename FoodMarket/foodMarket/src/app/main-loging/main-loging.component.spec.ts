import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainLogingComponent } from './main-loging.component';

describe('MainLogingComponent', () => {
  let component: MainLogingComponent;
  let fixture: ComponentFixture<MainLogingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainLogingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainLogingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
