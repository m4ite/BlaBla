import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunityManagementPageComponent } from './community-management-page.component';

describe('CommunityManagementPageComponent', () => {
  let component: CommunityManagementPageComponent;
  let fixture: ComponentFixture<CommunityManagementPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommunityManagementPageComponent]
    });
    fixture = TestBed.createComponent(CommunityManagementPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
