import { Injectable } from '@angular/core';
import { RegisterResponse } from 'src/app/DTO/user/register/register-response';
import { LoginResponse } from 'src/app/DTO/user/login/login-response';
import { UnSubscribeResponse } from 'src/app/DTO/user/unSubscribe/un-subscribe-response';

@Injectable({
  providedIn: 'root'
})
export class UserRepositoryService {

  constructor() { }

  register(registerFormValue: any): RegisterResponse {
    return null;
  }

  login(loginFormValue: any): LoginResponse {
    return null;
  }

  unSubscribe(unSubscribeFormValue: any): UnSubscribeResponse {
    return null;
  }
}
