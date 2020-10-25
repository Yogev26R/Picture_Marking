import { TestBed } from '@angular/core/testing';

import { SharedDocumentRemoteCommService } from './shared-document-remote-comm.service';

describe('SharedDocumentRemoteCommService', () => {
  let service: SharedDocumentRemoteCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedDocumentRemoteCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
