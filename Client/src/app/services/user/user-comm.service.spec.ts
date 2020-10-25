import { TestBed } from '@angular/core/testing';

import { UserCommService } from './user-comm.service';

describe('UserCommService', () => {
  let service: UserCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
