import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMemberPageComponent } from './edit-member-page.component';

describe('EditMemberPageComponent', () => {
  let component: EditMemberPageComponent;
  let fixture: ComponentFixture<EditMemberPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditMemberPageComponent]
    });
    fixture = TestBed.createComponent(EditMemberPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
