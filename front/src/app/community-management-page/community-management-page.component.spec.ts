import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CommunityManagementPageComponent } from './community-management-page.component';

describe('CommunityManagementPageComponent', () => {
  let component: CommunityManagementPageComponent;
  let fixture: ComponentFixture<CommunityManagementPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CommunityManagementPageComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CommunityManagementPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});