import { TestBed } from '@angular/core/testing';

import { UserLocalCommService } from './user-local-comm.service';

describe('UserLocalCommService', () => {
  let service: UserLocalCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserLocalCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
