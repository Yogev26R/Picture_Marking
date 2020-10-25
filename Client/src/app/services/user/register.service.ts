import { Injectable } from '@angular/core';
import { SubscribeService } from '../subscribe.service';
import { UserCommService } from './user-comm.service';
import { Subject } from 'rxjs';
import { RegisterDTO } from 'src/app/DTO/user/register/register-dto';
import { LoginDTO } from 'src/app/DTO/user/login/login-dto';
import { RegisterRequest } from 'src/app/DTO/user/register/register-request';

@Injectable({
  providedIn: 'root'
})
export class RegisterService extends SubscribeService {

  responseSubjects = {
    RegisterResponseOK: new Subject<any>(),
    RegisterResponseUserNameExists: new Subject<any>(),
    RegisterResponseEmailAddressExists: new Subject<any>()
  };

  constructor(private userCommService: UserCommService) {
    super();
  }

  register(registerFormValue: any) {
    const request = new RegisterRequest(this.registerFormToRequest(registerFormValue));
    console.log(request.register.login.userName);
    console.log(request.register.userID);
    this.subscribe(
      this.userCommService.register(request), this.responseSubjects);
  }

  onRegisterOK(): Subject<any> {
    return this.responseSubjects.RegisterResponseOK;
  }

  onRegisterUserNameExists(): Subject<any> {
    return this.responseSubjects.RegisterResponseUserNameExists;
  }

  onRegisterEmailAddressExists(): Subject<any> {
    return this.responseSubjects.RegisterResponseEmailAddressExists;
  }

  registerFormToRequest(registerFormValue): RegisterDTO {
    return new RegisterDTO(new LoginDTO(registerFormValue.userName.value), registerFormValue.emailAddress.value);
  }

}
