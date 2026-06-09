import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { NewCommunityPageComponent } from './new-community-page.component';

describe('NewCommunityPageComponent', () => {
  let component: NewCommunityPageComponent;
  let fixture: ComponentFixture<NewCommunityPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [NewCommunityPageComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(NewCommunityPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});