import { TestBed } from '@angular/core/testing';

import { MarkerRemoteCommService } from './marker-remote-comm.service';

describe('MarkerRemoteCommService', () => {
  let service: MarkerRemoteCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MarkerRemoteCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
