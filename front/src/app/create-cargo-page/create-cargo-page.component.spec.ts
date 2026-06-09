import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CreateCargoPageComponent } from './create-cargo-page.component';

describe('CreateCargoPageComponent', () => {
  let component: CreateCargoPageComponent;
  let fixture: ComponentFixture<CreateCargoPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CreateCargoPageComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CreateCargoPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});