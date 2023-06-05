import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';
import { BehaviorSubject } from 'rxjs';
import { UserDetails } from '../_models/userDetails';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.usersUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'api/users/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'api/users/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }

        return user;
      })
    )
  }

  getUser(email: string) {
    return this.http.get<UserDetails>(this.baseUrl + 'api/users', {
      params: {
        email: email
      }
    })
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  getCurrentUser() {
    const userString = localStorage.getItem('user');
    
    if (!userString) return;

    const user: User = JSON.parse(userString);

    return user;
  }
}
