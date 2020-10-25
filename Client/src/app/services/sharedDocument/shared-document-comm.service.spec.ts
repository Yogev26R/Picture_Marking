import { TestBed } from '@angular/core/testing';

import { SharedDocumentCommService } from './shared-document-comm.service';

describe('SharedDocumentCommService', () => {
  let service: SharedDocumentCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SharedDocumentCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
