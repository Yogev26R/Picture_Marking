import { TestBed } from '@angular/core/testing';

import { CreateSharedDocumentService } from './create-shared-document.service';

describe('CreateSharedDocumentService', () => {
  let service: CreateSharedDocumentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateSharedDocumentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
