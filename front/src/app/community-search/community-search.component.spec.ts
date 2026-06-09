import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CommunitySearchComponent } from './community-search.component';

describe('CommunitySearchComponent', () => {
  let component: CommunitySearchComponent;
  let fixture: ComponentFixture<CommunitySearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CommunitySearchComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CommunitySearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});