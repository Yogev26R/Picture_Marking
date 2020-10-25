import { TestBed } from '@angular/core/testing';

import { ReadDocumentService } from './read-document.service';

describe('ReadDocumentService', () => {
  let service: ReadDocumentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReadDocumentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
