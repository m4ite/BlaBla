import { of } from 'rxjs';

export const activatedRouteMock = {
  params: of({
    nickName: 'testNick',
    communityName: 'testCommunity'
  })
};

export const userServiceMock = {
  getMember: jasmine.createSpy().and.returnValue(of({
    email: 'test@test.com',
    nickName: 'test',
    wordPass: '123',
    birthdate: new Date(),
    foto: '',
    cargo: 1
  })),
  submit: jasmine.createSpy().and.returnValue(of({}))
};

export const cargoServiceMock = {
  GetCargo: jasmine.createSpy().and.returnValue(of([]))
};