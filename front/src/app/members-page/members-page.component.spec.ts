import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { MembersPageComponent } from './members-page.component';

describe('MembersPageComponent', () => {
  let component: MembersPageComponent;
  let fixture: ComponentFixture<MembersPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [MembersPageComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(MembersPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});