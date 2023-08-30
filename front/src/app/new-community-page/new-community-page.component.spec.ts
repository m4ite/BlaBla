import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCommunityPageComponent } from './new-community-page.component';

describe('NewCommunityPageComponent', () => {
  let component: NewCommunityPageComponent;
  let fixture: ComponentFixture<NewCommunityPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewCommunityPageComponent]
    });
    fixture = TestBed.createComponent(NewCommunityPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
