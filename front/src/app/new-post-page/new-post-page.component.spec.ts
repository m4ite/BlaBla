import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { NewPostPageComponent } from './new-post-page.component';

describe('NewPostPageComponent', () => {
  let component: NewPostPageComponent;
  let fixture: ComponentFixture<NewPostPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [NewPostPageComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(NewPostPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});