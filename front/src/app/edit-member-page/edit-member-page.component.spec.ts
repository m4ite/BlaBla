import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { EditMemberPageComponent } from './edit-member-page.component';

import { ActivatedRoute } from '@angular/router';

import { UserServiceService } from '../Services/UserService/user-service.service';
import { CargoService } from '../Services/CargoService/cargo.service';

import {
  activatedRouteMock,
  userServiceMock,
  cargoServiceMock
} from '../testing/test-mocks';

describe('EditMemberPageComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [EditMemberPageComponent],
      providers: [
        { provide: ActivatedRoute, useValue: activatedRouteMock },
        { provide: UserServiceService, useValue: userServiceMock },
        { provide: CargoService, useValue: cargoServiceMock }
      ]
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(EditMemberPageComponent);
    const component = fixture.componentInstance;

    fixture.detectChanges();

    expect(component).toBeTruthy();
  });
});