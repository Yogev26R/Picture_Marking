import { Injectable } from '@angular/core';
import { User } from '../DTO/user/user';
import { LoginService } from './user/login.service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  user: User;

  constructor(private loginService: LoginService) {
    this.loginService.onLoginOK().subscribe(
      response => this.user = new User(response.request.userID, response.request.login.userName)
    );
  }

  isLoggedIn(): boolean {
    return this.user ? true : false;
  }

  getUserName(): string {
    let retval = null;

    if (this.isLoggedIn()) {
      retval = this.user.userName;
    }
    return retval;
  }

  getUserID(): string {
    let retval = null;

    if (this.isLoggedIn()) {
      retval = this.user.userID;
    }

    return retval;
  }

  logout() {
    this.user = null;
  }
}
