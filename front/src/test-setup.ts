import { of } from 'rxjs';

/**
 * ActivatedRoute mock global
 */
export const activatedRouteMock = {
  params: of({
    nickName: 'testNick',
    communityName: 'testCommunity'
  }),
  snapshot: {
    paramMap: {
      get: (key: string) => {
        const data: any = {
          nickName: 'testNick',
          communityName: 'testCommunity'
        };
        return data[key];
      }
    }
  }
};

/**
 * UserService mock global
 */
export const userServiceMock = {
  getMember: jasmine.createSpy().and.returnValue(of({})),
  submit: jasmine.createSpy().and.returnValue(of({}))
};

/**
 * CargoService mock global
 */
export const cargoServiceMock = {
  GetCargo: jasmine.createSpy().and.returnValue(of([]))
};