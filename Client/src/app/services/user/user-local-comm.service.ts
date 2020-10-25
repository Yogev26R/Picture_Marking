import { Injectable } from '@angular/core';
import { UserCommService } from './user-comm.service';
import { Observable } from 'rxjs';
import { UserRepositoryService } from './user-repository.service';
import { RegisterResponse } from 'src/app/DTO/user/register/register-response';
import { LoginResponse } from 'src/app/DTO/user/login/login-response';
import { UnSubscribeResponse } from 'src/app/DTO/user/unSubscribe/un-subscribe-response';

@Injectable({
  providedIn: 'root'
})
export class UserLocalCommService implements UserCommService {

  constructor(private userRepositoryService: UserRepositoryService) { }

  register(registerFormValue: any): Observable<RegisterResponse> {
    return new Observable<RegisterResponse>(
      subscriber => subscriber.next(this.userRepositoryService.register(registerFormValue))
    );
  }
  login(loginFormValue: any): Observable<LoginResponse> {
    return new Observable<LoginResponse>(
      subscriber => subscriber.next(this.userRepositoryService.login(loginFormValue))
    );
  }
  unSubscribe(unSubscribeFormValue: any): Observable<UnSubscribeResponse> {
    return new Observable<UnSubscribeResponse>(
      subscriber => subscriber.next(this.userRepositoryService.unSubscribe(unSubscribeFormValue))
    );
  }
}
