import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainFoodsComponent } from './main-foods.component';

describe('MainFoodsComponent', () => {
  let component: MainFoodsComponent;
  let fixture: ComponentFixture<MainFoodsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainFoodsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainFoodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
