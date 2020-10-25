import { Injectable } from '@angular/core';
import { SubscribeService } from '../subscribe.service';
import { UserCommService } from './user-comm.service';
import { Subject } from 'rxjs';
import { LoginResponse } from 'src/app/DTO/user/login/login-response';
import { LoginRequest } from 'src/app/DTO/user/login/login-request';
import { LoginDTO } from 'src/app/DTO/user/login/login-dto';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends SubscribeService {

  responseSubjects = {
    LoginResponseOK: new Subject<LoginResponse>(),
    LoginResponseInvalidUserName: new Subject<LoginResponse>()
  };

  constructor(private userCommService: UserCommService) {
    super();
  }

  login(loginFormValue: any) {
    const request = new LoginRequest(this.loginFormToRequest(loginFormValue), null);
    this.subscribe(
      this.userCommService.login(request), this.responseSubjects);
  }

  onLoginOK() {
    return this.responseSubjects.LoginResponseOK;
  }

  onInvalidUserName() {
    return this.responseSubjects.LoginResponseInvalidUserName;
  }

  loginFormToRequest(loginFormValue): LoginDTO {
    return new LoginDTO(loginFormValue.userName.value);
  }
}
