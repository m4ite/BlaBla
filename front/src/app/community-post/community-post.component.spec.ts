import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunityPostComponent } from './community-post.component';

describe('CommunityPostComponent', () => {
  let component: CommunityPostComponent;
  let fixture: ComponentFixture<CommunityPostComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommunityPostComponent]
    });
    fixture = TestBed.createComponent(CommunityPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
