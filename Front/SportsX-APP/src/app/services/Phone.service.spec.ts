/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PhoneService } from './Phone.service';

describe('Service: Phone', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PhoneService]
    });
  });

  it('should ...', inject([PhoneService], (service: PhoneService) => {
    expect(service).toBeTruthy();
  }));
});
