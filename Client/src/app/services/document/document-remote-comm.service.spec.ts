import { TestBed } from '@angular/core/testing';

import { DocumentRemoteCommService } from './document-remote-comm.service';

describe('DocumentRemoteCommService', () => {
  let service: DocumentRemoteCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DocumentRemoteCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
