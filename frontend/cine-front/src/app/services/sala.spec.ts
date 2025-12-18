import { TestBed } from '@angular/core/testing';

import { SalaService } from './sala';

describe('Sala', () => {
  let service: SalaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
