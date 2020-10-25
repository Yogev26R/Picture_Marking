import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterRequest } from 'src/app/DTO/user/register/register-request';
import { RegisterResponse } from 'src/app/DTO/user/register/register-response';
import { LoginResponse } from 'src/app/DTO/user/login/login-response';
import { LoginRequest } from 'src/app/DTO/user/login/login-request';
import { UnSubscribeResponse } from 'src/app/DTO/user/unSubscribe/un-subscribe-response';
import { UnSubscribeRequest } from 'src/app/DTO/user/unSubscribe/un-subscribe-request';
import { UserCommService } from './user-comm.service';

@Injectable({
  providedIn: 'root'
})
export class UserRemoteCommService implements UserCommService {

  constructor(private httpClient: HttpClient) { }

  register(registerRequest: RegisterRequest): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>('api/register', registerRequest);
  }

  login(loginRequest: LoginRequest): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>('api/login', loginRequest);
  }

  unSubscribe(unSubscribeRequest: UnSubscribeRequest): Observable<UnSubscribeResponse> {
    return this.httpClient.post<UnSubscribeResponse>('api/unsubscribe', unSubscribeRequest);
  }
}
