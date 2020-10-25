import { TestBed } from '@angular/core/testing';

import { DocumentCommService } from './document-comm.service';

describe('DocumentCommService', () => {
  let service: DocumentCommService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DocumentCommService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
