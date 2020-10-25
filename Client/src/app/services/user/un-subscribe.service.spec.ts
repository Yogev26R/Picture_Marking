import { TestBed } from '@angular/core/testing';

import { UnSubscribeService } from './un-subscribe.service';

describe('UnSubscribeService', () => {
  let service: UnSubscribeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnSubscribeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
