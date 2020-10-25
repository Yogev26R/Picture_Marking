import { TestBed } from '@angular/core/testing';

import { UserRemoteCommService } from './user-remote-comm.service';

describe('UserRemoteCommService', () => {
  let service: UserRemoteCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserRemoteCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
