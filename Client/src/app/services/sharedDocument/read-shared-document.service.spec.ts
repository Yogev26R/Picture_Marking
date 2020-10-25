import { TestBed } from '@angular/core/testing';

import { ReadSharedDocumentService } from './read-shared-document.service';

describe('ReadSharedDocumentService', () => {
  let service: ReadSharedDocumentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReadSharedDocumentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
