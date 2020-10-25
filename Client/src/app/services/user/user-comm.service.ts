import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterResponse } from 'src/app/DTO/user/register/register-response';
import { RegisterRequest } from 'src/app/DTO/user/register/register-request';
import { LoginResponse } from 'src/app/DTO/user/login/login-response';
import { LoginRequest } from 'src/app/DTO/user/login/login-request';
import { UnSubscribeResponse } from 'src/app/DTO/user/unSubscribe/un-subscribe-response';
import { UnSubscribeRequest } from 'src/app/DTO/user/unSubscribe/un-subscribe-request';



@Injectable({
  providedIn: 'root'
})
export abstract class UserCommService {

  constructor() { }

  abstract register(RegisterRequest: RegisterRequest): Observable<RegisterResponse>;

  abstract login(loginRequest: LoginRequest): Observable<LoginResponse>;

  abstract unSubscribe(unSubscribeRequest: UnSubscribeRequest): Observable<UnSubscribeResponse>;
}
