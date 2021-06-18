import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { Constants } from '../util/Constants';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  public getAllUser(): Observable<User[]> {
    return this.http.get<User[]>(`${Constants.API_URL}user`);
  }

}
