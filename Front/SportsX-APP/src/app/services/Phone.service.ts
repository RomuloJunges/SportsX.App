import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Phone } from '../models/Phone';
import { Constants } from '../util/Constants';

@Injectable({
  providedIn: 'root',
})
export class PhoneService {
  constructor(private http: HttpClient) {}

  public getPhonesByUserId(userId: number): Observable<Phone[]> {
    return this.http.get<Phone[]>(`${Constants.API_URL}phone/${userId}`);
  }

  public savePhone(userId: number, phones: Phone[]): Observable<Phone[]> {
    return this.http.put<Phone[]>(
      `${Constants.API_URL}phone/update/${userId}`,
      phones
    );
  }

  public deletePhone(userId: number, phoneId: number) {
    return this.http.delete(`${Constants.API_URL}phone/${userId}/${phoneId}`);
  }
}
