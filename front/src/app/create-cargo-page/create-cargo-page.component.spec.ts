import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCargoPageComponent } from './create-cargo-page.component';

describe('CreateCargoPageComponent', () => {
  let component: CreateCargoPageComponent;
  let fixture: ComponentFixture<CreateCargoPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateCargoPageComponent]
    });
    fixture = TestBed.createComponent(CreateCargoPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
