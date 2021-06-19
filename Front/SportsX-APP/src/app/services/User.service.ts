import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { Constants } from '../util/Constants';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  public getAllUser(): Observable<User[]> {
    return this.http.get<User[]>(`${Constants.API_URL}user`);
  }

  public getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${Constants.API_URL}user/${id}`);
  }

  public deleteUser(id: number): Observable<any> {
    return this.http.delete(`${Constants.API_URL}user/${id}`);
  }

  public post(user: User): Observable<User> {
    return this.http.post<User>(`${Constants.API_URL}user/register`, user);
  }

  public put(user: User): Observable<User> {
    return this.http.put<User>(`${Constants.API_URL}user/update`, user);
  }
}
