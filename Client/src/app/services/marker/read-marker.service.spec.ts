import { TestBed } from '@angular/core/testing';

import { ReadMarkerService } from './read-marker.service';

describe('ReadMarkerService', () => {
  let service: ReadMarkerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReadMarkerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
